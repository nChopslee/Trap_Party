using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class Player2Controller : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        bool jump;
        Vector2 move;

        float friction = 1.0f; // 0 means no friction
        private Vector3 curVel = Vector3.zero;
        public bool onIce = false;

        //access player 2 controls
        public PlayerController player1;
        public Animator animator1;

        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                //ice code
                if (onIce)
                {
                    Vector3 dir = new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2")); // calculate the desired velocity:
                    Vector3 vel = transform.TransformDirection(dir) * maxSpeed;
                    curVel = Vector3.Lerp(curVel, vel, friction * Time.deltaTime);
                    move = curVel;
                }
                else
                {
                    move.x = Input.GetAxis("Horizontal2");
                }

                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump2"))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp("Jump2"))
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player2 = this;
                }
            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player2 = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player2 = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Ice"))
            {
                friction = 0.2f; // set low friction
                onIce = true;

            }
            if (col.CompareTag("Freeze"))
            {
                player1.controlEnabled = false;
                animator1.SetBool("isFrozen", true);
            }
	    if (col.CompareTag("Spring"))
	    {
		 jumpTakeOffSpeed = 14;
		 jumpState = JumpState.PrepareToJump;
	    }

        }

        void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Ice"))
            {
                friction = 1; // restore regular friction
                onIce = false;
            }
            if (col.CompareTag("Freeze"))
            {
                player1.controlEnabled = true;
                animator1.SetBool("isFrozen", false);
            }
	    if (col.CompareTag("Spring"))
            {
                jumpTakeOffSpeed = 7;
            }
        }
    }
}
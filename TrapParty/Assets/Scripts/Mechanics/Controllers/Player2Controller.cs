using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using UnityEngine.SceneManagement;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class Player2Controller : KinematicObject
    {
        

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7.2f;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/ public Collider2D collider2d;
        public Rigidbody2D rb;
        
        public Health health;
        public bool controlEnabled = true;
        float dt = 0.0f;

        bool jump;
        Vector2 move;

        float friction = 1.0f; // 0 means no friction
        private Vector3 curVel = Vector3.zero;
        public bool onIce = false;
        public bool onSnow = false;
        //public bool isWinner = false;

        //access player 2 controls
        public PlayerController player1;
        public Animator animator1;

        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        public FinalScore finalScore;

         

        void Awake()
        {
            health = GetComponent<Health>();
            
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            

            
        }

        

        protected override void Update()
        {
            if (dt > 5.0f)
            {
                dt = 0.0f;
                player1.controlEnabled = true;
                animator1.SetBool("isFrozen", false);
            }
            if (player1.controlEnabled == false)
            {
                dt += Time.deltaTime;
            }

            

            if (controlEnabled)
            {
            
                //ice code

                if (onSnow)
                {
                    //Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, 0); // calculate the desired velocity:
                    //Vector3 vel = transform.TransformDirection(dir);
                    rb.drag = 1;

                    //curVel = Vector3.Lerp(curVel, vel * 0, 0);
                    move.x = Input.GetAxis("Horizontal2");

                }
                else if (onIce)
                {
                    Vector3 dir = new Vector3(Input.GetAxis("Horizontal2"), 0, 0); // calculate the desired velocity:
                    Vector3 vel = transform.TransformDirection(dir) * 3f;
                    curVel = Vector3.Lerp(curVel, vel, friction * Time.deltaTime);
                    rb.drag = 0;

                    move = curVel;
                }
                else
                {
                    rb.drag = 0;
                    move.x = Input.GetAxis("Horizontal2");
                    friction = 1.0f;
                }


                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump2"))
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Jump");
                    jumpState = JumpState.PrepareToJump;
                }
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
            if (col.CompareTag("Snow"))
            {

                friction = 1.0f; // restore regular friction
                onSnow = true;

            }
            if (col.CompareTag("Ice"))
            {

                friction = .1f; // set low friction
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
            if (col.CompareTag("Final"))
            {
                animator.SetBool("isWinner", true);
                animator1.SetBool("isWinner", false);
            }

            if (col.CompareTag("Zone1"))
            {
                CurZone = 1.0f;
            }
            if (col.CompareTag("Zone2"))
            {
                CurZone = 2.0f;
            }
            if (col.CompareTag("Zone3"))
            {
                CurZone = 3.0f;
            }
            if (col.CompareTag("Zone0"))
            {
                CurZone = 0.0f;
            }
            if (col.CompareTag("Flame"))
            {
                TorchOn2 = 1.0f;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Torch2");

            }

        }

        void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Snow"))
            {
                onSnow = false;
            }
            if (col.CompareTag("Ice"))
            {
                onIce = false;
            }
            if (col.CompareTag("Spring"))
            {
                jumpTakeOffSpeed = 7.2f;
            }
            if (col.CompareTag("Flame"))
            {
                TorchOn2 = 0.0f;
            }
        }
        public float CurZone { get; private set; }
        public float TorchOn2 { get; private set; }
    }
}
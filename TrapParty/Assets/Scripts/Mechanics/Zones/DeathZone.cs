using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// DeathZone components mark a collider which will schedule a
    /// PlayerEnteredDeathZone event when the player enters the trigger.
    /// </summary>
    public class DeathZone : MonoBehaviour
    {


        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            var p2 = collider.gameObject.GetComponent<Player2Controller>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredDeathZone>();
                ev.deathzone = this;
            }
            if (p2 != null)
            {
                var ev2 = Schedule<Player2EnteredDeathZone>();
                ev2.deathzone = this;
            }
        }

        void OnParticleCollision(GameObject other)
        {
            var p = other.gameObject.GetComponent<PlayerController>();
            var p2 = other.gameObject.GetComponent<Player2Controller>();

            if (p != null)
            {
                var ev = Schedule<PlayerEnteredDeathZone>();
                ev.deathzone = this;
            }
            if (p2 != null)
            {
                var ev2 = Schedule<Player2EnteredDeathZone>();
                ev2.deathzone = this;
            }
        }

    }
}
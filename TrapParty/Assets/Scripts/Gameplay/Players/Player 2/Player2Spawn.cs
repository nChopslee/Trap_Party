using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player is spawned after dying.
    /// </summary>
    public class Player2Spawn : Simulation.Event<Player2Spawn>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player2 = model.player2;
            
            //player 2
            player2.collider2d.enabled = true;
            player2.controlEnabled = false;
            if (player2.audioSource && player2.respawnAudio)
                player2.audioSource.PlayOneShot(player2.respawnAudio);

            player2.health.Increment();
            player2.Teleport(model.spawnPoint2.transform.position);
            player2.jumpState = Player2Controller.JumpState.Grounded;
            player2.animator.SetBool("dead", false);

            //camera follow ****Needs States
            //model.virtualCamera2.m_Follow = player2.transform;
            //model.virtualCamera2.m_LookAt = player2.transform;


            Simulation.Schedule<EnablePlayerInput>(2f);
        }
    }
}
using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player performs a Jump.
    /// </summary>
    /// <typeparam name="PlayerJumped"></typeparam>
    public class PlayerJumped : Simulation.Event<PlayerJumped>
    {
        public PlayerController player;
        public Player2Controller player2;

        public override void Execute()
        {
            //if (player.jumpAudio)
                //player.audioSource.PlayOneShot(player.jumpAudio);
            //FMODUnity.RuntimeManager.PlayOneShot("event:/Player-1/Jump");
        }
    }
}
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;



namespace Platformer.Gameplay
{

    /// <summary>
    /// This event is triggered when the player character enters a trigger with a VictoryZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredVictoryZone"></typeparam>
    public class Player2EnteredVictoryZone : Simulation.Event<PlayerEnteredVictoryZone>
    {
        public VictoryZone victoryZone;

        private SceneTransition nextScene;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            model.player2.animator.SetTrigger("victory");
            model.player2.controlEnabled = false;
            model.player.animator.SetTrigger("lose");
            model.player.controlEnabled = false;
            nextScene.LoadLevel();
        }
    }
}
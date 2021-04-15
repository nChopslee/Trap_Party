using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{

    /// <summary>
    /// This event is triggered when the player character enters a trigger with a VictoryZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredVictoryZone"></typeparam>
    public class PlayerEnteredVictoryZone : Simulation.Event<PlayerEnteredVictoryZone>
    {
        public VictoryZone victoryZone;

        public SceneTransition nextScene =  new SceneTransition();

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();


        public override void Execute()
        {
            
            model.player.animator.SetTrigger("victory");
            model.player.controlEnabled = false;
            model.player2.animator.SetTrigger("lose");
            model.player2.controlEnabled = false;
            nextScene.LoadLevel();
        }

    }
}
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    
    public class VictoryZone : MonoBehaviour
    {

        private PlayerScores ps =  new PlayerScores();
        public SceneTransition st;
        public MusicControl musicSystem;

        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                Debug.Log("Entering Win Zone");
                var ev = Schedule<PlayerEnteredVictoryZone>();
                ev.victoryZone = this;
                //CurP1++;
                ps.playerOneScoreIncrement();
                Debug.Log("Incrementing p1 score" + ps.getPlScore());
                musicSystem.Stop();
                st.startTransition();
            }

            var p2 = collider.gameObject.GetComponent<Player2Controller>();
            if (p2 != null)
            {
                Debug.Log("Entering Win Zone");
                var ev = Schedule<Player2EnteredVictoryZone>();
                ev.victoryZone = this;
                //CurP1++;
                ps.playerTwoScoreIncrement();
                Debug.Log("Incrementing p1 score" + ps.getP2Score());
                musicSystem.Stop();
                st.startTransition();
            }
        }

       // public int CurP1 { get; private set; }
        //public int curP2 { get; private set; }
    }
}
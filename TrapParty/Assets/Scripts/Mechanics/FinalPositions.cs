using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPositions : MonoBehaviour
{
    public FinalScore finalScore;
    public GameObject player1;
    public GameObject player2;
    public Platformer.Mechanics.PlayerController player1C;
    public Platformer.Mechanics.Player2Controller player2C;

    private Scene scene; 

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (scene.name == "FinalScene")
        {
            player1C.animator.SetBool("final",true);
            player2C.animator.SetBool("final", true);

            if (finalScore.P1Wins)
            {
                player1.transform.position = new Vector3(-0.87f, -0.55f, 0);
                player1.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
                player2.transform.position = new Vector3(1.6f, -1.9f, 0);
                player2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                player1C.animator.SetBool("isWinner", true);
            }
            if (finalScore.P2Wins)
            {
                player2.transform.position = new Vector3(-0.87f, -0.55f, 0);
                player2.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
                player1.transform.position = new Vector3(1.6f, -1.9f, 0);
                player1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                player2C.animator.SetBool("isWinner", true);
            }
            if (finalScore.Draw)
            {
                player1.transform.position = new Vector3(1.2f, -1.0f, 0);
                player1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                player2.transform.position = new Vector3(1.8f, -1.0f, 0);
                player2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                player1C.animator.SetBool("isWinner", false);
                player2C.animator.SetBool("isWinner", false);
                //animator.SetBool("isWinner", false);

            }
        }
    }
}

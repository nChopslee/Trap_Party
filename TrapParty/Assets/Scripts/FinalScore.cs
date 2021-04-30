using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FinalScore : MonoBehaviour
{
    private ScoreText scoreText;
    private PlayerDeaths playerDeaths;

    private bool p1Wins = false;
    private bool p2Wins = false;
    private bool draw = false;

    private TextMeshProUGUI finalScores;
    
    // Start is called before the first frame update
    void Start()
    {
        finalScores = GameObject.Find("FinalScoreText").GetComponent<TextMeshProUGUI>();
        playerDeaths = GameObject.Find("PlayerDeaths").GetComponent<PlayerDeaths>();
        scoreText = GameObject.Find("ScoreText").GetComponent<ScoreText>();
    }


    // Update is called once per frame
    void Update()
    {
        if ((scoreText.P1 == 4 && scoreText.P2 == 0) ||
            (scoreText.P1 == 3 && scoreText.P2 == 1))
        {
            p1Wins = true;
            finalScores.text = $"Player 1 Wins";


        }
        if ((scoreText.P1 == 0 && scoreText.P2 == 4) ||
            (scoreText.P1 == 1 && scoreText.P2 == 3))
        {
            p2Wins = true;
            finalScores.text = $"Player 2 Wins";
        }

        if (scoreText.P1 == 2 && scoreText.P2 == 2){
            if (playerDeaths.getP1Deaths() > playerDeaths.getP2Deaths())
            {
                p2Wins = true;
                finalScores.text = $"Player 2 Wins";
            }
            if (playerDeaths.getP1Deaths() < playerDeaths.getP2Deaths())
            {
                p1Wins = true;
                finalScores.text = $"Player 1 Wins";
            }
            else
            {
                draw = true;
                finalScores.text = $"No One Wins - Play Again";
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    private Text playerScores;
    //private Text playerTwoScore;
    //private PlayerScores ps;
    
 

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Finding PlayerScores Object");
        playerScores = GameObject.Find("Score/Canvas/PlayerScores").GetComponent<Text>();
        Debug.Log(playerScores);
        P1 = PlayerPrefs.GetInt("PlayerScore");
        P2 = PlayerPrefs.GetInt("PlayerTwoScore");
        playerScores.text = $"{P1} - {P2}";
        //playerTwoScore.text = $"- {p2}";
    }

    public int P1 { get; private set; }

    public int P2 { get; private set; }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    private Text playerScores;
    //private Text playerTwoScore;
    private PlayerScores ps = new PlayerScores();
    


    // Start is called before the first frame update
    void Start()
    {
        playerScores = GameObject.Find("PlayerScores").GetComponent<Text>();
        //playerTwoScore = GameObject.Find("PlayerTwoScore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        P1 = ps.getPlScore();
        P2 = ps.getP2Score();
        playerScores.text = $"{P1} - {P2}";
        //playerTwoScore.text = $"- {p2}";
    }

    public int P1 { get; private set; }

    public int P2 { get; private set; }

}

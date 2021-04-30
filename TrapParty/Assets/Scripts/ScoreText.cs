using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    private Text playerOneScore;
    private Text playerTwoScore;
    private PlayerScores ps = new PlayerScores();
    private int p1;
    private int p2;


    // Start is called before the first frame update
    void Start()
    {
        playerOneScore = GameObject.Find("PlayerOneScore").GetComponent<Text>();
        playerTwoScore = GameObject.Find("PlayerTwoScore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        p1 = ps.getPlScore();
        p2 = ps.getP2Score();
        playerOneScore.text = $"{p1} -";
        playerTwoScore.text = $"- {p2}";
    }
}

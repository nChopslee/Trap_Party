using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Model;
using Platformer.Mechanics;




public class PlayerScores : MonoBehaviour
{
    int PlayerScore
    {
        
        get
        {
            return PlayerPrefs.GetInt("PlayerScore", 0);
        }

        set
        {
            PlayerPrefs.SetInt("PlayerScore", value);
        }

    }

    int PlayerTwoScore
    {
        get
        {
            return PlayerPrefs.GetInt("PlayerTwoScore", 0);
        }

        set
        {
            PlayerPrefs.SetInt("PlayerTwoScore", value);
        }
    }

    public void playerOneScoreIncrement()
    {
        PlayerScore++;
        Debug.Log("PlayerScore: " + PlayerScore);
    }

    public void playerTwoScoreIncrement()
    {
        PlayerTwoScore++;
        Debug.Log("Player 2 Score: " + PlayerTwoScore);
    }

    public int getPlScore()
    {
        return this.PlayerScore;
    }

    public int getP2Score()
    {
        return this.PlayerTwoScore;

    }
}


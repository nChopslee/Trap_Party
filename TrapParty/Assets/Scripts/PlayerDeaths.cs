using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeaths : MonoBehaviour
{
   


    int PlayerOneDeaths
    {
        get
        {
            return PlayerPrefs.GetInt("PlayerOneDeaths", 0);
        }
        
        set
        {
            PlayerPrefs.SetInt("PlayerOneDeaths", value);
        }
    }

    int PlayerTwoDeaths
    {
        get
        {
            return PlayerPrefs.GetInt("PlayerTwoDeaths", 0);

        }
        set
        {
            PlayerPrefs.SetInt("PlayerTwoDeaths", value);

        }

    }

    public void p1DeathInc()
    {
        PlayerOneDeaths++;
        Debug.Log("P1 Deaths: " + PlayerOneDeaths);
    }

    public void p2DeathInc()
    {
        PlayerTwoDeaths++;
        Debug.Log("P2 Deaths: " + PlayerTwoDeaths);
    }

    public int getP1Deaths()
    {
        return this.PlayerOneDeaths;
    }

    public int getP2Deaths()
    {
        return this.PlayerTwoDeaths;
    }
}

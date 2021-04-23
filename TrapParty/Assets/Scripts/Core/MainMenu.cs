using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public MusicControl musicSystem;

    public void ExitButton() {
	    Application.Quit();
	    Debug.Log("You have exited out of the game");
    }

    public void StartButton() {
        PlayerPrefs.SetInt("PlayerScore", 0);
        PlayerPrefs.SetInt("PlayerTwoScore", 0);
       musicSystem.Stop();
       SceneManager.LoadScene("Trap_Party_0.1");
       // SceneManager.LoadScene("AdditiveScene", LoadSceneMode.Additive);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton() {
	Application.Quit();
	Debug.Log("You have exited out of the game");
    }

    public void SettingsButton() {
	SceneManager.LoadScene("Settings");
    }

    public void CreditsButton() {
	SceneManager.LoadScene("Credits");
    }

    public void StartButton() {
	SceneManager.LoadScene("Trap_Party_0.2_Jungle");
    }
}

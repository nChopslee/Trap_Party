using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public MusicControl musicSystem;

    public void MenuButton() {
        musicSystem.Stop();
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControl : MonoBehaviour
{
    public Platformer.Mechanics.PlayerController player1;
    public Platformer.Mechanics.Player2Controller player2;
    private float temp = 0.0f;
    FMOD.Studio.STOP_MODE IMMEDIATE;

    [FMODUnity.EventRef]
    public string music;
    //public bool sameMusic;
    FMOD.Studio.EventInstance musicEvent;

    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        chooseEvent();
        musicEvent = FMODUnity.RuntimeManager.CreateInstance(music);
        //checkSameMusic();
        musicEvent.start();
    }

    public void Stop()
    {
        musicEvent.stop(IMMEDIATE);
    }

    public void Zone()
    {
        if (player1.CurZone >= player2.CurZone)
        {
            temp = player1.CurZone;
        }
        else if (player1.CurZone < player2.CurZone)
        {
            temp = player2.CurZone;
        }
        musicEvent.setParameterByName("Zone", temp);
        
    }

    public void TorchOn()
    {
        if (player1.TorchOn == 1.0f)
        {
            temp = 1.0f;
        }
        if (player1.TorchOn == 0.0f)
        {
            temp = 0.0f;
        }
        musicEvent.setParameterByName("TorchOn", temp);
    }

    public void TorchOn2()
        {
            if (player2.TorchOn2 == 1.0f)
        {
            temp = 1.0f;
        }
        if (player2.TorchOn2 == 0.0f)
        {
            temp = 0.0f;
        }
        musicEvent.setParameterByName("TorchOn", temp);
    }
       

    public void chooseEvent()
    {
        if (scene.name == "Menu")
        {
            music = "event:/MenuMusic";
        }
        if (scene.name == "Settings")
        {
            music = "event:/SettingsCredits";
        }
        if (scene.name == "Credits")
        {
            music = "event:/SettingsCredits";
        }
        if (scene.name == "Trap_Party_0.1")
        {
            music = "event:/DungeonMusic";
        }
        if (scene.name == "Trap_Party_0.2_Jungle")
        {
            music = "event:/JungleMusic";
        }
        if (scene.name == "Trap_Party_0.2_Ice")
        {
            music = "event:/IceMusic";
        }
        if (scene.name == "Trap_Party_0.5_Flame3")
        {
            music = "event:/FlameMusic";
        }
        if (scene.name == "FinalScene")
        {
            music = "event:/FinalMusic";
        }



    }

    //public void checkSameMusic()
    //{

    //}

}

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
    FMOD.Studio.EventInstance musicEvent;

    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        chooseEvent();
        musicEvent = FMODUnity.RuntimeManager.CreateInstance(music);
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

    public void chooseEvent()
    {
        if (scene.name == "Menu")
        {
            music = "event:/MenuMusic";
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
        if (scene.name == "Trap_Party_0.2_Flame2")
        {
            music = "event:/FlameMusic";
        }

    }

}

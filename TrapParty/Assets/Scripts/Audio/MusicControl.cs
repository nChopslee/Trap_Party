using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public Platformer.Mechanics.PlayerController player1;
    public Platformer.Mechanics.Player2Controller player2;
    private float temp = 0.0f;
    FMOD.Studio.STOP_MODE IMMEDIATE;

    [FMODUnity.EventRef]
    public string music = "event:/IceMusic";
    FMOD.Studio.EventInstance musicEvent;

    // Start is called before the first frame update
    void Start()
    {
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
    
}

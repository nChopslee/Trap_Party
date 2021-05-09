using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCarry : MonoBehaviour
{
    private SpriteRenderer p1;
    private SpriteRenderer p2;
    private string p1Parse;
    private string p2Parse;
    private bool p1True = false;
    private bool p2True = false;

    private void Start()
    {
        p1 = GameObject.Find("Player 1").GetComponent<SpriteRenderer>();
        p2 = GameObject.Find("Player 2").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        p1Parse = PlayerPrefs.GetString("PlayerOneColor");
        p2Parse = PlayerPrefs.GetString("PlayerTwoColor");
        p1True = ColorUtility.TryParseHtmlString("#" + p1Parse, out Color p1c);
        p2True = ColorUtility.TryParseHtmlString("#" + p2Parse, out Color p2c);
        if(p1True)
            p1.color = p1c;
        if(p2True)
            p2.color = p2c;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSaver : MonoBehaviour
{
    private SpriteRenderer p1;
    private SpriteRenderer p2;
    [SerializeField] private Color p1C;
    [SerializeField]private Color p2C;

    private void Start()
    {
        p1 = GameObject.Find("Player 1").GetComponent<SpriteRenderer>();
        p2 = GameObject.Find("Player 2").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        p1C = p1.color;
        p2C = p2.color;
        PlayerPrefs.SetString("PlayerOneColor", ColorUtility.ToHtmlStringRGB(p1C));
        PlayerPrefs.SetString("PlayerTwoColor", ColorUtility.ToHtmlStringRGB(p2C));
    }
}

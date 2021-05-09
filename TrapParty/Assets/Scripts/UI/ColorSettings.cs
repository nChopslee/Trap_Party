using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSettings : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject player;
    [SerializeField] private Color[] colors;
    private int colorValue;

    void Start() {
	spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Update() {
    }

    public void ChangeMaterial() {

	colorValue++;
	
	if(colorValue > 8) {
	    colorValue = 0;
	}

	spriteRenderer.color = colors[colorValue];
    }
}

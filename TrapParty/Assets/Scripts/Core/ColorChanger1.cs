using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger1 : MonoBehaviour
{
    public Renderer spriteRenderer;
    public GameObject player1;
    [SerializeField] private Color[] colors;
    private int colorValue;

    void Start() {
	spriteRenderer = player1.GetComponent<Renderer>();
    }

    void Update() {
    }

    public void ChangeMaterial() {

	colorValue++;
	
	if(colorValue > 2) {
	    colorValue = 0;
	}

	spriteRenderer.material.color = colors[colorValue];
    }
}

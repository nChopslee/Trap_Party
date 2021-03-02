using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashSpikeTrigger : MonoBehaviour
{
    
    public PatrolLR patroller;
    public PatrolUD patroller2;
    public PatrolUD patroller3;
    public PatrolUD patroller4;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            patroller.isMoving = true;
            patroller2.isMoving = true;
            patroller3.isMoving = true;
            patroller4.isMoving = true;
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            patroller.isMoving = false;
            patroller2.isMoving = false;
            patroller3.isMoving = false;
            patroller4.isMoving = false;

        }
    }
}

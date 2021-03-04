using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbineTrigger : MonoBehaviour
{
    
    //public Orbit orbit;
    public GameObject turbine;
    public GameObject turbine2;
    public GameObject turbine3;
    public GameObject turbineR;
    public GameObject turbineR2;
    public GameObject turbineR3;


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
            turbine.GetComponent<Orbit>().orbrate = 100;
            turbine2.GetComponent<Orbit>().orbrate = 100;
            turbine3.GetComponent<Orbit>().orbrate = 100;
            //***MUST FILL PUBLIC GAME OBJECT WITH EMPTY OBJECT and ORBIT SCRIPT
            //***IF IT IS FIRST IN LINE. 
            turbineR.GetComponent<Orbit>().orbrate = -100;
            turbineR2.GetComponent<Orbit>().orbrate = -100;
            turbineR3.GetComponent<Orbit>().orbrate = -100;
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            turbine.GetComponent<Orbit>().orbrate = 10;
            turbine2.GetComponent<Orbit>().orbrate = 10;
            turbine3.GetComponent<Orbit>().orbrate = 10;

            turbineR.GetComponent<Orbit>().orbrate = -10;
            turbineR2.GetComponent<Orbit>().orbrate = -10;
            turbineR3.GetComponent<Orbit>().orbrate = -10;

        }
    }
}

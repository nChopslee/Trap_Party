using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrigger : MonoBehaviour
{
    
    public GameObject lava;
    public GameObject lava1;
    public GameObject lava2;
    public GameObject lava3;


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
            lava.SetActive(true);
            lava1.SetActive(true);
            lava2.SetActive(true);
            lava3.SetActive(true);
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            lava.SetActive(false);
            lava1.SetActive(false);
            lava2.SetActive(false);
            lava3.SetActive(false);

        }
    }
}

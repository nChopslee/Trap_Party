using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTrigger : MonoBehaviour
{
    
    public GameObject missile;
    public GameObject missile2;
    public GameObject missile3;
    public GameObject missile4;


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
            missile.SetActive(true);
            missile2.SetActive(true);
            missile3.SetActive(true);
            missile4.SetActive(true);
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            missile.SetActive(false);
            missile2.SetActive(false);
            missile3.SetActive(false);
            missile4.SetActive(false);

        }
    }
}

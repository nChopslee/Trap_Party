using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrigger : MonoBehaviour
{
    
    public ParticleSystem Fire;
    public ParticleSystem Fire1;
    public ParticleSystem Fire2;
    public ParticleSystem Fire3;
    public ParticleSystem Fire4;
    public ParticleSystem Fire5;
    public ParticleSystem Fire6;
    public ParticleSystem Fire7;


    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        Fire1.maxParticless
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Fire.SetActive(true);
            Fire1.SetActive(true);
            Fire2.SetActive(true);
            Fire3.SetActive(true);
            Fire4.SetActive(true);
            Fire5.SetActive(true);
            Fire6.SetActive(true);
            Fire7.SetActive(true);
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Fire.SetActive(false);
            Fire1.SetActive(false);
            Fire2.SetActive(false);
            Fire3.SetActive(false);
            Fire4.SetActive(false);
            Fire5.SetActive(false);
            Fire6.SetActive(false);
            Fire7.SetActive(false);

        }
    }
}

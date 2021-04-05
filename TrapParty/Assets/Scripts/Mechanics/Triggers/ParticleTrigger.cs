using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    
    private ParticleSystem ps;
    public FireTrigger[] fts;
    public int numbParticles;
    

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem.MainModule main = ps.main;
        
        foreach(FireTrigger ftrig in fts)
        {
            
            //Debug.Log();
            if (ftrig.isTriggered())
            {
          
                main.maxParticles = numbParticles;
                break;
            }
            else
            {
                main.maxParticles = 0;
            }

            
        }
        
    }


}

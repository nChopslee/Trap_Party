using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMultiply : MonoBehaviour
{
    public GameObject myPrefab = null;      //initializes call for the prefab object
    public Transform myBurstPos = null;     //initializes call for the transform, should use groundcheck's transform
    public bool playerWon = false;       //boolean to control instantiation
    public float burstDuration;            //length of time until instance is destroyed

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerWon)
        {
            //make an instance of the burst prefab
            GameObject burst = Instantiate(myPrefab, myBurstPos.position, myBurstPos.rotation);//instantiate prefab at groundcheck transform

            if (burst != null)
            {
                //kill instantiation
                Destroy(burst, burstDuration);
            }
        }
        playerWon = false; //breakingUp always false unless true
    }

    public void MultiplyPlayer()     //public function called when frozen and hurt are true 
    {
        playerWon = true;

    }
}

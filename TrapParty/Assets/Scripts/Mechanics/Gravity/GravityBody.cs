using UnityEngine;

//Auto Insert Rigidbody
[RequireComponent (typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    //public GameObject closest = null;
    #region Public Properties
    public GravityAttractor attractor = null;

    public int Grounded { get; private set; } = 0;

    #endregion

    #region Private Properties
    #endregion

    private void Awake()
	{
		GetComponent<Rigidbody>().WakeUp();
		GetComponent<Rigidbody>().useGravity = false;
		GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	private void OnCollisionEnter(Collision c)
	{
        
		if(c.gameObject.tag == "Planet")
		{
			Grounded++;
		}
        
    }

	private void OnCollisionExit(Collision c)
	{
		if(c.gameObject.tag == "Planet" && Grounded > 0)
		{
			Grounded--;
		}
       
    }
	
	private void FixedUpdate()
	{
		if(attractor != null)
		{
            //attractor = Closest.parent; the object's (w/ gravity tag) parent = attractor
			attractor.Attract(this);
		}
		
	}

    
}

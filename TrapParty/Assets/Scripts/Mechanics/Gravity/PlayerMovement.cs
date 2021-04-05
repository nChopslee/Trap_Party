using UnityEngine;

public class PlayerMovement : GravityBody
{

    #region Public Properties
    public float maxSpeed = 15f;
    public float force = 12f;
    public float jumpSpeed = 1f;
    public PlayerRocket rocket;
    public int invert = -1;
    public Vector3 sun = Vector3.zero;
    //public MusicControl musicSystem;


    #endregion

    #region Public Properties
    private bool _jump = false;
    #endregion



    private void Update()
    {
        //jump command
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }


        //musicSystem.DistanceToSun();
    }

    //jump functionality
    public void Jump()
    {
        _jump = true;

        if (Grounded == 0)
        {
            _jump = false;
            rocket.Fire(this);
        }


    }

    private void FixedUpdate()
    {
        
        attractor = FindClosestGravity().GetComponent<GravityAttractor>();

        //attractor
        if (attractor != null)
        {
            attractor.Attract(this);
        }

        //movement as rotation 
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {

            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                
                GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.right * HorizontalForce);

                //**To move in 3 dimensions around the Attractor Objects add this
                // GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.forward * (VerticalForce * invert));
            }
            else
            {
                
                GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.right * ((Input.acceleration.x * 6) * force));

                //**To move in 3 dimensions around the Attractor Objects add this
                //GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.forward * ((Input.acceleration.y * 6) * force) * invert);
            }

        }

        if (_jump == true)
        {

            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + (GetComponent<Rigidbody>().transform.up * jumpSpeed);
            _jump = false;
        }
    }

    //controls
    public float HorizontalForce
    {
        get
        {
            return Input.GetAxis("Horizontal") * force;
        }
    }

    public float VerticalForce
    {
        get
        {
            return Input.GetAxis("Vertical") * force;
        }
    }

    public float DistToSun
    {

        get
        {
            Vector3 dist = sun - transform.position;
            float distSun = (dist.sqrMagnitude) / 10;
            return distSun;
        }
    }


    //find closest gravity attractor object
    public GameObject FindClosestGravity()
    {

        GameObject closest = null;
        GameObject[] planets;
        planets = GameObject.FindGameObjectsWithTag("Gravity");

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject planet in planets)
        {
            Vector3 diff = planet.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = planet;
                distance = curDistance;
            }
        }

        return closest;

    }
   
}

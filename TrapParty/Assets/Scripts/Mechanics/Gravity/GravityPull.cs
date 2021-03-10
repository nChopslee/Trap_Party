
using UnityEngine;
//This will activate gravitational pull on 
//whatever object this is attached to. "Could" be seperated from the Player Movement script if necessary.

public class GravityPull: GravityBody
{
    private void FixedUpdate()
    {

        attractor = FindClosestGravity().GetComponent<GravityAttractor>();

        if (attractor != null)
        {
            attractor.Attract(this);
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

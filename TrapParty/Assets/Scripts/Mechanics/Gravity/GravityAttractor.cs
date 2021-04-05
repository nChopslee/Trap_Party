using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    #region Public Properties
    public float gravity = -10.0f;
    #endregion

    public void Attract(GravityBody body)
    {
        Transform trans = body.transform;
        Rigidbody rigid = body.GetComponent<Rigidbody>();

        Vector3 gravityUp = trans.position - transform.position;
        gravityUp.Normalize();

        rigid.AddForce(gravityUp * gravity * rigid.mass);

        //check if grounded and friction
        if (body.Grounded >= 1)
        {
            rigid.drag = 0.1f;
        }
        else
        {
            rigid.drag = 20.0f;
        }

        //allows the rotation of the object
        if (rigid.freezeRotation == true)
        {
            Quaternion quatern = Quaternion.FromToRotation(trans.up, gravityUp);
            quatern = quatern * trans.rotation;
            trans.rotation = Quaternion.Slerp(trans.rotation, quatern, 0.1f);
        }
    }
}

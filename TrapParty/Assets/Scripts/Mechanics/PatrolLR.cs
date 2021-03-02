using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLR : MonoBehaviour
{
    protected Vector2 velocity;
    public Transform _transform;
    public float distance = 1f;
    
    public float speed = 5f;
    Vector3 _originalPosition;
    public bool isGoingLeft = false;
    public float distFromStart;
    public bool isMoving = false;
    public bool rightSide;

    public void Start()
    {
        _originalPosition = gameObject.transform.position;
        _transform = GetComponent<Transform>();
        velocity = new Vector2(speed, 0);
        _transform.Translate(velocity.x * Time.deltaTime, 0, 0);
        
    }

    void Update()
    {
        distFromStart = transform.position.x - _originalPosition.x;

        if (rightSide)
        {
            if (isGoingLeft && isMoving)
            {
                // If gone too far, switch direction
                if (transform.position.x < _originalPosition.x)
                    SwitchDirection();

                _transform.Translate(velocity.x * Time.deltaTime, 0, 0);
            }
            else if (isMoving)
            {
                // If gone too far, switch direction

                if (distFromStart > distance)
                    SwitchDirection();

                _transform.Translate(-velocity.x * Time.deltaTime, 0, 0);
            }

            if (!isMoving && transform.position.x > _originalPosition.x)
            {
                _transform.Translate(velocity.x / speed * Time.deltaTime, 0, 0);
            }
        }
        else
        {

            if (isGoingLeft && isMoving)
            {
                // If gone too far, switch direction
                if (distFromStart < -distance)
                    SwitchDirection();

                _transform.Translate(-velocity.x * Time.deltaTime, 0, 0);
            }
            else if (isMoving)
            {
                // If gone too far, switch direction

                if (transform.position.x > _originalPosition.x)
                    SwitchDirection();

                _transform.Translate(velocity.x * Time.deltaTime, 0, 0);
            }

            if (!isMoving && transform.position.x < _originalPosition.x)
            {
                _transform.Translate(velocity.x / speed * Time.deltaTime, 0, 0);
            }
        }



    }

    void SwitchDirection()
    {
        isGoingLeft = !isGoingLeft;
        //TODO: Change facing direction, animation, etc
    }
}

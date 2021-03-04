using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolUD : MonoBehaviour
{
    protected Vector2 velocity;
    public Transform _transform;
    public float distance = 1f;
    
    public float speed = 5f;
    Vector2 _originalPosition;
    public bool isGoingUp = false;
    public float distFromStart;
    public bool isMoving = false;
    public bool upSpike;

    public void Start()
    {
        _originalPosition = gameObject.transform.position;
        _transform = GetComponent<Transform>();
        velocity = new Vector2(0, speed);
        _transform.Translate(0, 0, 0);
        
    }

    void Update()
    {
        distFromStart = transform.position.y - _originalPosition.y;

            if (isGoingUp && isMoving)
            {
                // If gone too far, switch direction
                if (distFromStart < -distance)
                    SwitchDirection();

                _transform.Translate(0, -velocity.y * Time.deltaTime, 0);
            }
            else if (isMoving)
            {
                // If gone too far, switch direction
                if (distFromStart > distance)
                    SwitchDirection();

                _transform.Translate(0, velocity.y * Time.deltaTime, 0);
            }

        if (!isMoving && transform.position.y < _originalPosition.y)
        {
            _transform.Translate(0, velocity.y / speed * Time.deltaTime, 0);

        }
        else if(!isMoving && transform.position.y > _originalPosition.y)
        {
            _transform.Translate(0, -velocity.y / speed * Time.deltaTime, 0);
           
            
        }

        
    }

        void SwitchDirection()
        {
            isGoingUp = !isGoingUp;
            //TODO: Change facing direction, animation, etc
        }
    }

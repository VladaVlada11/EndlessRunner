using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    public float minXPosition = -2;
    public float maxXPosition = 2;
    public float stepDistance = 2;

    public float laneTransitionSpeed = 10;
    //minimumXPosition = -2
    //maximumXPosition = 2
    //stepDistance = 2

    private float destinationX;
    private bool hasReachedDestination = true;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        if(rb == null) 
        {
            Debug.LogError($"No rigidbody found on object: {gameObject.name}");
        }
    }

    
    void Update()
    {
        //if 'A' or left arrow pressed
        if (hasReachedDestination && Input.GetKeyDown(KeyCode.A)) 
        {
            //if player x position > minimumXPosition
            if (gameObject.transform.position.x > minXPosition) 
            {
                //move player rigidbody on x axis by -stepDistance
                /*gameObject.transform.position = new Vector3(
                    gameObject.transform.position.x - stepDistance,
                    gameObject.transform.position.y,
                    gameObject.transform.position.z
                    );*/
                destinationX = gameObject.transform.position.x-stepDistance;
                hasReachedDestination = false;
            }
        }

        //if 'D' or right arrow pressed
        if (hasReachedDestination && Input.GetKeyDown(KeyCode.D))
        {
            //  if player x position < maximumXPosition
            if (gameObject.transform.position.x < maxXPosition)
            {
                // move player rigidbody on x axis by stepDistance
                /*gameObject.transform.position = new Vector3(
                    gameObject.transform.position.x + stepDistance,
                    gameObject.transform.position.y,
                    gameObject.transform.position.z
                    );*/
                destinationX = gameObject.transform.position.x + stepDistance;
                hasReachedDestination = false;
            }
        }

        if (!hasReachedDestination) 
        {
            if (destinationX < gameObject.transform.position.x)
            {
                gameObject.transform.position = new Vector3(
                    gameObject.transform.position.x - laneTransitionSpeed * Time.deltaTime,
                    gameObject.transform.position.y,
                    gameObject.transform.position.z
                    );

                if (gameObject.transform.position.x <= destinationX)
                {
                    hasReachedDestination = true;
                    gameObject.transform.position = new Vector3(
                        destinationX,
                        gameObject.transform.position.y,
                        gameObject.transform.position.z
                        );
                }

            }
            else 
            {
                gameObject.transform.position = new Vector3(
                    gameObject.transform.position.x + laneTransitionSpeed * Time.deltaTime,
                    gameObject.transform.position.y,
                    gameObject.transform.position.z
                    );

                if (gameObject.transform.position.x >= destinationX)
                {
                    hasReachedDestination = true;
                    gameObject.transform.position = new Vector3(
                        destinationX,
                        gameObject.transform.position.y,
                        gameObject.transform.position.z
                        );
                }
            }

            
        }
        //smooth transition
    }
}

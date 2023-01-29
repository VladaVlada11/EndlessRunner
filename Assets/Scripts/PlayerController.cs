using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    
    public float minXPosition = -2;
    public float maxXPosition = 2;
    public float stepDistance = 2;

    public float laneTransitionSpeed = 10;
    //minimumXPosition = -2
    //maximumXPosition = 2
    //stepDistance = 2

    private float destinationX;
    private bool hasReachedDestination = true;
    private bool isLeft = false;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        if(rb == null) 
        {
            Debug.LogError($"No rigidbody found on object: {gameObject.name}");
        }
        anim= GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError($"No animator found on object: {gameObject.name}");
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
                destinationX = gameObject.transform.position.x - stepDistance;
                hasReachedDestination = false;
                isLeft = true;
            }
        }

        //if 'D' or right arrow pressed
        if (hasReachedDestination && Input.GetKeyDown(KeyCode.D))
        {
            //  if player x position < maximumXPosition
            if (gameObject.transform.position.x < maxXPosition)
            {
                // move player rigidbody on x axis by stepDistance
                destinationX = gameObject.transform.position.x + stepDistance;
                hasReachedDestination = false;
                isLeft = false;
            }
        }
        
        if (!hasReachedDestination)
        {
            if (isLeft)
            {
                rb.velocity = new Vector3(-laneTransitionSpeed * Time.deltaTime, 0, 0);

                if (gameObject.transform.position.x <= destinationX)
                {
                    hasReachedDestination = true;
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.position = new Vector3(
                        destinationX,
                        rb.position.y,
                        rb.position.z
                        );
                }

            }
            else
            {
                rb.velocity = new Vector3(laneTransitionSpeed * Time.deltaTime, 0, 0);

                if (gameObject.transform.position.x >= destinationX)
                {
                    hasReachedDestination = true;
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.position = new Vector3(
                        destinationX,
                        rb.position.y,
                        rb.position.z
                        );
                    
                }
            }


        }
        else 
        {
            //rb.velocity = new Vector3(0, 0, 0);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("Death");
            Die();
        }
    }

    public void Die() 
    {
        GameObject.FindWithTag("GameController").GetComponent<GameManager>().StopGame();
        anim.SetTrigger("Die");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; // allows gameObject to react to real-time physics
    private Animator anim; // ontrols the logic of an animated gameObject

    // our character's positions on X (initial middle position = 0)
    public float minXPosition = -2; // the leftmost position
    public float maxXPosition = 2; // the rightmost position
    public float positionsDistance = 2; // distance between character's positions

    public float lineTransitionSpeed = 10; // speed with which character moves between lines

    private float destinationX; // desired destination line, in which we want to move our character 
    private bool hasReachedDestination = true;
    private bool isLeft = false;

    void Start()
    { // for comfort usage: in case we forget to connect rigidBody or animator to our character

        rb = GetComponent<Rigidbody>(); // defining of rigidBody

        if(rb == null) 
        {
            Debug.LogError($"No rigidbody found on object: {gameObject.name}");
        }
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError($"No animator found on object: {gameObject.name}");
        }
    }
    
    void Update()
    {
        if (hasReachedDestination && Input.GetKeyDown(KeyCode.A)) // when 'A' or left arrow are pressed
        {
            if (gameObject.transform.position.x > minXPosition) // if character's X position > minimum/left position, then:
            { 
                // character's rigidb is moved on X axis by -positionDistance
                destinationX = gameObject.transform.position.x - positionsDistance;
                hasReachedDestination = false;
                isLeft = true;
            }
        }

        if (hasReachedDestination && Input.GetKeyDown(KeyCode.D)) // when 'D' or right arrow are pressed
        {
            if (gameObject.transform.position.x < maxXPosition) // if character's X position < maximum/right position, then:
            {
                // character's rigidbody is moved on X axis by positionDistance
                destinationX = gameObject.transform.position.x + positionsDistance;
                hasReachedDestination = false;
                isLeft = false;
            }
        }
        
        if (!hasReachedDestination)
        {
            if (isLeft)
            { 
                // velocity represents the rate of change of Rigidbody position
                rb.velocity = new Vector3(-lineTransitionSpeed * Time.deltaTime, 0, 0);

                if (gameObject.transform.position.x <= destinationX)
                {
                    hasReachedDestination = true;
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.position = new Vector3(destinationX, rb.position.y, rb.position.z); //character's position on X axis is changed
                }
            }
            else
            {
                rb.velocity = new Vector3(lineTransitionSpeed * Time.deltaTime, 0, 0);

                if (gameObject.transform.position.x >= destinationX)
                {
                    hasReachedDestination = true;
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.position = new Vector3(destinationX, rb.position.y, rb.position.z);
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

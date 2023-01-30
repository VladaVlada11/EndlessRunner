using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    // obstacle is falling from the sky to the road

    private Rigidbody rb;
    private Animator anim;
    public float obstacleInitialPosition = 3;
    
    public float minDist = 10;
    //public float distanceBetweenCharacterAndObstacle = 15;
    public float obstaclePositionOnRoad = 0;
    public float fallingSpeed = 10;

    private GameObject player;
    private bool isFalling = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        float dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
       
        if (dist < minDist)
        {
            //Fall();
            //Debug.Log(dist);
            isFalling = true;
        }
        if (isFalling) 
        {
            Fall();
        }
        /*You can calculate distance from object using Vector3.Distance(object.position, player.position);
        float minDist = 2;
        float dist = Vector3.Distance(other.position, transform.position);
        if (dist < minDist)
        {
            pickup();
        }*/

        /*if (gameObject.transform.position.x - obstaclePositionOnRoad)
        {
            isFalling = true;
                rb.velocity = new Vector3(0, 0, 0);
                rb.position = new Vector3(rb.position.x, obstaclePositionOnRoad, rb.position.z);
        }*/

        /*float dist = Vector3.Distance(gameObject.transform.position, obstaclePositionOnRoad);
        if (dist < minDist)
        {
            isFalling = true;
            rb.velocity = new Vector3(0, 0, 0);
            rb.position = new Vector3(rb.position.x, obstaclePositionOnRoad, rb.position.z);
        }*/
    }

    void Fall()
    {
        rb.velocity = new Vector3(0, -fallingSpeed * Time.deltaTime, 0);
        //rb.position = new Vector3(rb.position.x, obstaclePositionOnRoad, rb.position.z);
    }
}
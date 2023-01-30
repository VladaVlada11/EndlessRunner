using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleMovingRoad : MonoBehaviour
{
    public List<GameObject> wholeRoadList;
    public float movementSpeed = 2;
    public bool isMoving = true;
    void Start()
    {
        if(wholeRoadList != null && wholeRoadList.Count > 0)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            gameObject.transform.position = new Vector3(0, 0, gameObject.transform.position.z - movementSpeed * Time.deltaTime);
        }
    }
}

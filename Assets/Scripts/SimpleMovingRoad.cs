using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleMovingRoad : MonoBehaviour
{
    public List<GameObject> wholeRoadList;
    public float movementSpeed = 2;
    void Start()
    {
        if(wholeRoadList != null && wholeRoadList.Count > 0)
        {
            
        }
    }

    /*public void moveRoad()
    {
        GameObject movedRoad = wholeRoadList[0];
        wholeRoadList.Remove(movedRoad);
        float newPositionZ = wholeRoadList[wholeRoadList.Count - 1].transform.position.z + roadLength;
     movedRoad.transform.position = new Vector3(0,0,newPositionZ );
        wholeRoadList
    }*/

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(0, 0, gameObject.transform.position.z - movementSpeed*Time.deltaTime);

        
    }
}

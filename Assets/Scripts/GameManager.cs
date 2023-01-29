using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SimpleMovingRoad road;

    public void StopGame() 
    {
        road.isMoving = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

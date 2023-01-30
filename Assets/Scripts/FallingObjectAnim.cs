using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectAnim : MonoBehaviour
{
    private Animator anim;
    public float minDist = 10;
    private GameObject player;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (dist < minDist)
        {
            anim.SetTrigger("Fall");
        }
    }
}

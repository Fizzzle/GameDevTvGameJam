using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovent : MonoBehaviour
{

    
    public NavMeshAgent NavMeshAgent;
    
    public Transform groundChecking;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;
    bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
    }

    public virtual void WhenClickOnGround(Vector3 point)
    {
        NavMeshAgent.SetDestination(point);
    }

    void CheckGround()
    {
        isGround = Physics.CheckSphere(groundChecking.position, groundDistance, GroundMask);
        if (!isGround)
        {
            NavMeshAgent.speed = 0;
        }
        else
        {
            NavMeshAgent.speed = 3;
        }
    }
}

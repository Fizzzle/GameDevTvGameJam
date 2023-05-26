using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


// Author Viktor
public class PlayerMovent : MonoBehaviour
{

    [Header("MoveSetting Settings")]
    public NavMeshAgent NavMeshAgent;
    
    [Header("GroundChecking Settings")]
    public Transform groundChecking;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;
    public bool isGround;

    // Update is called once per frame
    void Update()
    {
        CheckGround();
    }

    public virtual void WhenClickOnGround(Vector3 point, int MoveSpeed = 3)
    {
        NavMeshAgent.SetDestination(point);
        NavMeshAgent.speed = MoveSpeed;
    }

    void CheckGround()
    {
        isGround = Physics.CheckSphere(groundChecking.position, groundDistance, GroundMask);
    }
}

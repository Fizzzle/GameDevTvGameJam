using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


// Author Viktor
public class PlayerMovent : MonoBehaviour
{
    public PlayerMove PlayerMove;

    [Header("MoveSetting Settings")]
    public NavMeshAgent NavMeshAgent;

    public bool isMove;

    [Header("GroundChecking Settings")]
    public Transform groundChecking;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;
    public bool isGround;

    private void Start()
    {
        isMove = true;
    }

    //Katya add...
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StartPos")
        {
            NavMeshAgent.enabled = false;
            isMove = false;
            PlayerMove.MoveAfterRotate();
            Debug.Log("other.gameObject.tag" + "++++");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        IgnoreLayerMaskOfHintTrigger();
        //Katya add...
        PlayerMove.FollowThePath();
    }

    public virtual void WhenClickOnGround(Vector3 point, int MoveSpeed = 3)
    {
        //Viktor
        if (isMove)
        {
            NavMeshAgent.SetDestination(point);
        }

        NavMeshAgent.speed = MoveSpeed;
    }

    void CheckGround()
    {
        isGround = Physics.CheckSphere(groundChecking.position, groundDistance, GroundMask);
    }


    // функция для игнора слой маски триггера подсказок - Serhii
    void IgnoreLayerMaskOfHintTrigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // создаем LayerMask, чтобы исключить слой "HintTrigger"
            LayerMask mask = ~LayerMask.GetMask("HintTrigger");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                //Viktor
                if (isMove)
                {
                    NavMeshAgent.SetDestination(hit.point);
                }

            }
        }
    }
}

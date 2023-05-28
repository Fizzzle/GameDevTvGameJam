using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxx : MonoBehaviour
{
    public Transform target;
    public float parallaxFactor = 0.5f;

    private Vector3 startPosition;
    private Vector3 previousTargetPosition;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        startPosition = target.position;
        previousTargetPosition = target.position;
    }

    private void Update()
    {
        Vector3 deltaMovement = target.position - previousTargetPosition;
        Vector3 parallaxOffset = deltaMovement * parallaxFactor;

        for (int i = 0; i < transform.childCount; i++)
        {
            RectTransform childRectTransform = transform.GetChild(i).GetComponent<RectTransform>();
            childRectTransform.localPosition += parallaxOffset;
        }

        previousTargetPosition = target.position;
    }
}

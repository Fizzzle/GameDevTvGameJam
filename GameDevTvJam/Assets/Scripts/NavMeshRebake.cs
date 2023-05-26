using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshRebake : MonoBehaviour
{
    private void Start()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
        StartCoroutine(WaitStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<NavMeshSurface>().BuildNavMesh();
            StartCoroutine(ReTestNav());
        }
    }

    IEnumerator ReTestNav()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}

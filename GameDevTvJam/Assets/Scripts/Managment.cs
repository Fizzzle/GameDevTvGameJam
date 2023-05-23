using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Author Viktor
public class Managment : MonoBehaviour
{
    
    [Header("Player Setting")]
    public Camera Camera;
    public PlayerMovent PlayerMovent;
    
    [Header("Effect Settings")]
    public ParticleSystem ClickEffect;
    
    // Update is called once per frame
    void Update()
    {
        
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red);

        RaycastHit hit = default;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider.tag == "Ground")
                {
                    ParticleSystem effectClick = Instantiate(ClickEffect, hit.point,
                        Quaternion.LookRotation(Camera.transform.position));
                    PlayerMovent.WhenClickOnGround(hit.point);
                    Destroy(effectClick, 1f);
                } 
            }
        }
        
        
    }

    void LetsGo()
    {
        RaycastHit hit = default;
        
    }
}

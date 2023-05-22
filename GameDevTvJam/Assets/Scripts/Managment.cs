using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managment : MonoBehaviour
{
    public Camera Camera;

    public PlayerMovent PlayerMovent;
    // Start is called before the first frame update
    void Start()
    {
    }

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
                    PlayerMovent.WhenClickOnGround(hit.point);
                } 
            }
        }
        
        
    }

    void LetsGo()
    {
        RaycastHit hit = default;
        
    }
}

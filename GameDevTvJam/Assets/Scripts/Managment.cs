using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Author Viktor
public class Managment : MonoBehaviour
{

    [Header("Player Setting")]
    public Camera Camera;
    public PlayerMovent PlayerMovent;
    public Rotate Rotate;

    [Header("Effect Settings")]
    public ParticleSystem ClickEffect;
    public ParticleSystem ClickEffectMiss;



    private void Start()
    {

        Camera = Camera.main;
        PlayerMovent = GameObject.FindObjectOfType<PlayerMovent>();

    }

    // Update is called once per frame
    void Update()
    {
        Rotate.RotateFigure();

        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = default;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Ground")
                {
                    PlayerMovent.WhenClickOnGround(hit.point);
                    if (ClickEffect != null)
                    {
                        ParticleSystem effectClick = Instantiate(ClickEffect, hit.point,
                            Quaternion.LookRotation(Camera.transform.position));
                        Destroy(effectClick.gameObject, 1);
                    }

                }

                //Katya add...
                else if (hit.collider.tag == "StartPos")
                {
                    if (PlayerMovent.isMove)
                    {
                        Rotate.Rotation();
                    }


                }

                else
                {
                    if (ClickEffectMiss != null)
                    {
                        ParticleSystem EffectMiss = Instantiate(ClickEffectMiss, hit.point,
                            Quaternion.LookRotation(Camera.transform.position));
                        Destroy(EffectMiss.gameObject, 1);
                    }
                }
            }
            // Пока тут самоповтор кода, вдруг не пригодиться, чтобы не заморачиваться зря
            if (Input.GetMouseButtonUp(1))
            {
                if (hit.collider.tag == "Ground")
                {
                    PlayerMovent.WhenClickOnGround(hit.point, 5);
                    if (ClickEffect != null)
                    {
                        ParticleSystem effectClick = Instantiate(ClickEffect, hit.point,
                            Quaternion.LookRotation(Camera.transform.position));
                        Destroy(effectClick, 1);
                    }

                }
            }
        }
    }


}

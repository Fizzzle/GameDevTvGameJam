using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSide : MonoBehaviour
{
    public GameObject LightSider;
    public GameObject DarkSider;
    private bool SwitchSider = false;

    // Start is called before the first frame update
    void Awake()
    {
        LightSider = GameObject.FindWithTag("LightSide");
        DarkSider = GameObject.FindWithTag("DarkSide");
    }

    private void Start()
    {
        DarkSider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SwitchSider)
            {
                LightSider.SetActive(true);
                DarkSider.SetActive(false);
                SwitchSider = !SwitchSider;
            }
            else
            {
                LightSider.SetActive(false);
                DarkSider.SetActive(true);
                SwitchSider = !SwitchSider;
            }
            
        }
    }
}

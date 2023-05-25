using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Author Viktor
public class SwitchSide : MonoBehaviour
{
    [Header("Side Settings")]
    public GameObject LightSider;
    public GameObject DarkSider;
    private bool SwitchSider = false;
    public bool HideDark = true;
    private PlayerMovent PlayerMovent;

    [Header("Side Settings")] public GameObject Wheels;
    public GameObject Cap;
    public GameObject Glasses;
    public GameObject DarkLight;


    [Header("Effects Settings")] public ParticleSystem LightSideEffects;
    public ParticleSystem DarkSideEffects;
    public Image DamageImage;


    // Start is called before the first frame update
    void Awake()
    {
        PlayerMovent = FindObjectOfType<PlayerMovent>();
        LightSider = GameObject.FindGameObjectWithTag("LightSide");
        DarkSider = GameObject.FindGameObjectWithTag("DarkSide");
    }

    private void Start()
    {
        Wheels = GameObject.Find("Wheels");
        Cap = GameObject.Find("Cap");
        Glasses = GameObject.Find("Glasses");
        DarkLight = GameObject.Find("DarkLight");
        
        if (HideDark)
        {
            LightSideSkin();
            LightSider.SetActive(true);
            DarkSider.SetActive(false);
        }
        else
        {
            DarkSideSkin();
            DarkSider.SetActive(true);
            LightSider.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        DarkSiderProperties();
        Switch();
    }

    void Switch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // AudioManager.Instance.PlayIllusionSwitchSound();

            
            if (SwitchSider)
            {
                
                LightSider.SetActive(true);
                DarkSider.SetActive(false);
                StartCoroutine(CheckerLight());
                SwitchSider = !SwitchSider;
                if (DarkSideEffects != null)
                {
                    if (LightSider.active)
                    {
                        LightSideSkin();
                        DarkSideEffects.Play();
                    }
                }
                
            }
            else
            {
                LightSider.SetActive(false);
                DarkSider.SetActive(true);
                StartCoroutine(CheckerDark());
                SwitchSider = !SwitchSider;
                if (LightSideEffects != null)
                {
                    if (DarkSider.active)
                    {
                        DarkSideSkin();
                        LightSideEffects.Play();
                    }
                }
                
            }
            
            
        }
    }

    IEnumerator CheckerDark()
    {
        yield return new WaitForSeconds(0.1f);
        if (PlayerMovent.isGround == false)
        {
            LightSider.SetActive(true);
            DarkSider.SetActive(false);
            StartCoroutine(ShowEffectDamage());
        }
    }
    
    IEnumerator CheckerLight()
    {
        yield return new WaitForSeconds(0.1f);
        if (PlayerMovent.isGround == false)
        {
            LightSider.SetActive(false);
            DarkSider.SetActive(true);
            StartCoroutine(ShowEffectDamage());
        }
    }
    
    IEnumerator ShowEffectDamage()
    {
        if (DamageImage != null)
        {
            DamageImage.enabled = true;
            for (float t = 0.9f; t > 0f; t-= Time.deltaTime * 0.5f)
            {
                DamageImage.color = new Color(0f, 0.4912767f, 1f, t);
                yield return null;
            }
            DamageImage.enabled = false;
        }
        
    }

    void DarkSiderProperties()
    {
        if (DarkSider.active)
        {
            
            Time.timeScale = 0.7f;
        }
        else
        {
            
            Time.timeScale = 1f;
        }
    }

    void LightSideSkin()
    {
        Wheels.SetActive(true);
        Cap.SetActive(true);
        Glasses.SetActive(false);
        DarkLight.SetActive(false);
    }
    void DarkSideSkin()
    {
        Glasses.SetActive(true);
        DarkLight.SetActive(true);
        Wheels.SetActive(false);
        Cap.SetActive(false);
    }
}

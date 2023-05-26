using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


// Author Viktor
public class SwitchSide : MonoBehaviour
{
    [Header("Side Settings")]
    public GameObject LightSider;
    public GameObject DarkSider;
    private bool SwitchSider = false;
    private bool SwitchActive = true;
    public bool HideDark = true;
    private PlayerMovent PlayerMovent;

    [Header("Side Settings")] public GameObject Wheels;
    public GameObject Cap;
    public GameObject Glasses;
    public GameObject DarkLight;


    [Header("Effects Settings")] public ParticleSystem LightSideEffects;
    public ParticleSystem DarkSideEffects;
    public Image DamageImage;
    public ParticleSystem LightMagicEffect;
    public ParticleSystem DarkMagicEffect;

    [Header("Background Settings")] public Image LightBackgroundImage;
    public Image DarkBackgroundImage;


    // Start is called before the first frame update
    void Awake()
    {
        PlayerMovent = FindObjectOfType<PlayerMovent>();
        LightSider = GameObject.FindGameObjectWithTag("LightSide");
        DarkSider = GameObject.FindGameObjectWithTag("DarkSide");
    }

    private void Start()
    {
        LightSideEffects = GameObject.FindWithTag("LightSideEffect").GetComponent<ParticleSystem>();
        DarkSideEffects = GameObject.FindWithTag("DarkSideEffect").GetComponent<ParticleSystem>();
        LightMagicEffect = GameObject.Find("LightMagicEffect").GetComponent<ParticleSystem>();
        DarkMagicEffect = GameObject.Find("DarkMagicEffect").GetComponent<ParticleSystem>();
        DamageImage = GameObject.Find("DamageScreen").GetComponent<Image>();
        Wheels = GameObject.Find("Wheels");
        Cap = GameObject.Find("Cap");
        Glasses = GameObject.Find("Glasses");
        DarkLight = GameObject.Find("DarkLight");
        LightBackgroundImage = GameObject.Find("BackgroundLight").GetComponent<Image>();
        DarkBackgroundImage = GameObject.Find("BackgroundDark").GetComponent<Image>();
        
        if (HideDark)
        {
            LightSideSkin();
            LightSider.SetActive(true);
            DarkSider.SetActive(false);
            lightBackground();
        }
        else
        {
            DarkSideSkin();
            DarkSider.SetActive(true);
            LightSider.SetActive(false);
            darkBackground();
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
            if (SwitchActive)
            {
                // AudioManager.Instance.PlayIllusionSwitchSound();
                if (SwitchSider)
                {
                    SwitchSiderLight();
                }
                else
                {
                    SwitchSiderDark();

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
            yield return new WaitForSeconds(0.05f);
            if (LightSider.active)
            {
                LightSideSkin();
                SwitchSider = !SwitchSider;
                lightBackground();

            }
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
            yield return new WaitForSeconds(0.05f);
            if (DarkSider.active)
            {
                DarkSideSkin();
                SwitchSider = !SwitchSider;
                darkBackground();
            }
            
        }
        
    }
    
    IEnumerator ShowEffectDamage()
    {
        if (DamageImage != null)
        {
            SwitchActive = false;
            DamageImage.enabled = true;
            for (float t = 0.9f; t > 0f; t-= Time.deltaTime * 0.5f)
            {
                DamageImage.color = new Color(0f, 0.4912767f, 1f, t);
                yield return null;
            }
            SwitchActive = true;
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

    void SwitchSiderLight()
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
                lightBackground();
                DarkSideEffects.Play();
                if (LightMagicEffect != null)
                {
                    LightMagicEffect.Play();
                }
            }
        }
    }

    void SwitchSiderDark()
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
                darkBackground();
                LightSideEffects.Play();
                if (DarkMagicEffect != null)
                {
                    DarkMagicEffect.Play();
                }
            }
        }
    }

    void lightBackground()
    {
        LightBackgroundImage.enabled = true;
        DarkBackgroundImage.enabled = false;
    }

    void darkBackground()
    {
        LightBackgroundImage.enabled = false;
        DarkBackgroundImage.enabled = true;
    }
}

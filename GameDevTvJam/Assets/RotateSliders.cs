using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateSliders : MonoBehaviour
{
 
    [SerializeField] private Slider xSlider, ySlider, zSlider;
    
    [SerializeField] private GameObject figureMain;

    public void ChangeValue()
    {
        Quaternion newRotation = Quaternion.Euler(xSlider.value, ySlider.value, zSlider.value);
        figureMain.transform.rotation = newRotation;
    }

}

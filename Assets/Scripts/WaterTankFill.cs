using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterTankFill : MonoBehaviour
{

    [SerializeField] Slider slider;

    public void SetMaxWater(int maxValue) 
    {
        slider.maxValue = maxValue;
    }

    public void setWaterFill(int value) 
    {
        slider.value = value;
    }

    private void Start()
    {
        slider.value = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour
{
    private Slider powerSlider;
    float time =0f;
    private bool timerRestart = false;
    private float sliderValue;
    public bool kicked = false;
    [SerializeField] GameObject powerSliderObject;
    void Start()
    {
        powerSlider = GetComponent<Slider>(); 
    }
    void Update()
    {
        CheckTimerRestart();
        TimeAndValueUpdate();
    }

    private void CheckTimerRestart()
    {
        if (time >= 1.5f && !timerRestart)
        {
            timerRestart = true;
        }
        if (time <= 0 && timerRestart)
        {
            timerRestart= false;
        }
    }

    private void TimeAndValueUpdate()
    {
        if (!kicked && powerSliderObject.activeSelf)
        {
            if (timerRestart)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time += Time.deltaTime;
            }
            sliderValue = time / 1.5f;
            powerSlider.value = sliderValue;
        }       
    }

    public float GetSliderValue()
    {
        return sliderValue;
    }
}

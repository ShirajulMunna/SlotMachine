using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParcentageHandler : MonoBehaviour
{
   
    public Slider[] parcentageSliders;
    private float noMatch, watch, cameraGift, laptop, bag, mobile;
    public int giftitemCount;

    void OnEnable()
    {

        giftitemCount = GameManager.Instance.giftItemCount;
        //Parcentages
        // noMatch = PlayerPrefs.GetFloat("NoMatch");
        watch = PlayerPrefs.GetFloat("Watch");
        cameraGift = PlayerPrefs.GetFloat("Camera");
        laptop = PlayerPrefs.GetFloat("Laptop");
        bag = PlayerPrefs.GetFloat("Bag");
        mobile = PlayerPrefs.GetFloat("Mobile");


        UpdateNoMatchSlider();
        UpdateClockSlider();
        UpdateCameraSlider();
        UpdateLaptopSlider();
        UpdateBagSlider();
        UpdateMobileSlider();

       

        
    }

    public void UpdateNoMatchSlider() 
    {
       

        if (giftitemCount == 3)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_3.0");
            parcentageSliders[0].value = getValue;


        }
        else if (giftitemCount == 4)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_4.0");
            parcentageSliders[0].value = getValue;

        }
        else if (giftitemCount == 5) 
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_4.0");
            parcentageSliders[0].value = getValue;
        }
      
    
    }
    public void UpdateClockSlider()
    {
        if (giftitemCount == 3)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_3.1");
            parcentageSliders[1].value = getValue;


        }
        else if (giftitemCount == 4)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_4.1");
            parcentageSliders[1].value = getValue;

        }
        else if (giftitemCount == 5)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_5.1");
            parcentageSliders[1].value = getValue;
        }

    }
    public void UpdateCameraSlider()
    {
        if (giftitemCount == 3)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_3.2");
            parcentageSliders[2].value = getValue;


        }
        else if (giftitemCount == 4)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_4.2");
            parcentageSliders[2].value = getValue;

        }
        else if (giftitemCount == 5)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_5.2");
            parcentageSliders[2].value = getValue;
        }

    }
    public void UpdateLaptopSlider()
    {
        if (giftitemCount == 3)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_3.3");
            parcentageSliders[3].value = getValue;


        }
        else if (giftitemCount == 4)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_4.3");
            parcentageSliders[3].value = getValue;

        }
        else if (giftitemCount == 5)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_5.3");
            parcentageSliders[3].value = getValue;
        }

    }
    public void UpdateBagSlider()
    {
        if (giftitemCount == 3)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_3.4");
            parcentageSliders[4].value = 0;


        }
        else if (giftitemCount == 4)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_4.4");
            parcentageSliders[4].value = getValue;

        }
        else if (giftitemCount == 5)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_5.4");
            parcentageSliders[4].value = 0;
        }

    }
    public void UpdateMobileSlider()
    {
        if (giftitemCount == 3)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_3.5");
            parcentageSliders[5].value = 0;


        }
        else if (giftitemCount == 4)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_4.5");
            parcentageSliders[5].value = 0;

        }
        else if (giftitemCount == 5)
        {
            float getValue = PlayerPrefs.GetFloat("sliderValue_5.5");
            parcentageSliders[5].value = getValue;
        }

    }
   


}

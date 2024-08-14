﻿using JGM.Game.Audio;
using JGM.Game.Events;
using JGM.Game.Patterns;
using JGM.Game.Rewards;
using JGM.Game.Rollers;
using ModestTree;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject text_percentageSlider1;
    public GameObject text_percentageSlider2;
    public GameObject text_percentageSlider3;
    public GameObject text_percentageSlider4;
    public GameObject text_percentageSlider5;
    public GameObject text_percentageSlider6;

    public GameObject text_RollingSpeedSlider;
    public GameObject text_RollingTimeSlider;
    public GameObject text_RollingItemSlider;

    public float[] sliderValue = { 0,50,50,50,50,50};
    public float rollingTime;
    public float rollingSpeed;
    public float rollingItem;

    public RollerManager rollerManager;

    public Slider[] sliders;
    public GameObject[] belowBox;
    public int particleStyleMode;

    public AudioClip winingClip;
    public AudioSource AudioSource;
    public GameObject adminPanel;

    public float overAllpercentage=100;
    public int selectedParcentages;
    public TMP_InputField[] parcentageBoxs;
    public GameObject gameButton;
    public GameObject parcentagesOverFlow;

   
    public int moveSpeed;
    public int rotationSpeed_1;
    public int rotationSpeed_2;
    public int rotationSpeed_3;

    public int quitValue;
    public int itemCount;
    public int[] percentValues;
    public int sum = 0;
    public int giftItemCount;
    public GameObject[] sliderImages;
    public TextMeshProUGUI totalThreshold;
    public bool isActivateOnce,isLocked;
    


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        quitValue = PlayerPrefs.GetInt("Quit");
        giftItemCount = PlayerPrefs.GetInt("gift",3);
        moveSpeed = rotationSpeed_1;
        AudioSource = GetComponent<AudioSource>();
        
        foreach (Slider slider in sliders)
        {
            slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(slider); });
            
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            adminPanel.SetActive(true);
        }
    }

    private void OnSliderValueChanged(Slider changedSlider)
    {
        
        int sliderIndex = sliders.IndexOf(changedSlider);

        switch (sliderIndex) 
        {
            case 0:
                Debug.Log("slider" + sliderIndex + " " + "value is " + changedSlider.value);
                if (changedSlider.value > 3 && changedSlider.value < 97)
                {
                    text_percentageSlider1.SetActive(true);
                }
                else
                {
                    text_percentageSlider1.SetActive(false);
                }

                if (giftItemCount == 3)
                {

                    PlayerPrefs.SetFloat("sliderValue_3.0", changedSlider.value);
                    Debug.Log("sliderValue_0.0");

                }
                else if (giftItemCount == 4)
                {

                    PlayerPrefs.SetFloat("sliderValue_4.0", changedSlider.value);
                    Debug.Log("sliderValue_0.1");


                }
                else if (giftItemCount == 5)
                {

                    PlayerPrefs.SetFloat("sliderValue_5.0", changedSlider.value);
                    Debug.Log("sliderValue_0.2");


                }

            
                parcentageBoxs[0].text = changedSlider.value.ToString();

         

                setSlider(0);
                break;
            case 1:
                Debug.Log("slider" + sliderIndex + " " + "value is " + changedSlider.value);
                if (changedSlider.value > 3 && changedSlider.value < 97)
                {
                    text_percentageSlider1.SetActive(true);
                }
                else
                {
                    text_percentageSlider1.SetActive(false);
                }
                if (giftItemCount == 3)
                {

                    PlayerPrefs.SetFloat("sliderValue_3.1", changedSlider.value);
                    Debug.Log("sliderValue_1.0");

                }
                else if (giftItemCount == 4)
                {

                    PlayerPrefs.SetFloat("sliderValue_4.1", changedSlider.value);
                    Debug.Log("sliderValue_1.1");


                }
                else if (giftItemCount == 5)
                {

                    PlayerPrefs.SetFloat("sliderValue_5.1", changedSlider.value);
                    Debug.Log("sliderValue_1.2");


                }

              
                parcentageBoxs[1].text = changedSlider. value.ToString();
         


                setSlider(0);
                break;
            case 2:
                Debug.Log("slider" + sliderIndex + " " + "value is " + changedSlider.value);
                if (changedSlider.value > 3 && changedSlider.value < 97)
                {
                    text_percentageSlider2.SetActive(true);
                }
                else
                {
                    text_percentageSlider2.SetActive(false);
                }
                if (giftItemCount == 3)
                {

                    PlayerPrefs.SetFloat("sliderValue_3.2", changedSlider.value);
                    Debug.Log("sliderValue_0.0");

                }
                else if (giftItemCount == 4)
                {

                    PlayerPrefs.SetFloat("sliderValue_4.2", changedSlider.value);
                    Debug.Log("sliderValue_0.1");


                }
                else if (giftItemCount == 5)
                {

                    PlayerPrefs.SetFloat("sliderValue_5.2", changedSlider.value);
                    Debug.Log("sliderValue_0.2");


                }

          
                parcentageBoxs[2].text = changedSlider.value.ToString();
       

                break;
            case 3:
                Debug.Log("slider" + sliderIndex + " " + "value is " + changedSlider.value);
                if (changedSlider.value > 3 && changedSlider.value < 97)
                {
                    text_percentageSlider3.SetActive(true);
                }
                else
                {
                    text_percentageSlider3.SetActive(false);
                }
                if (giftItemCount == 3)
                {

                    PlayerPrefs.SetFloat("sliderValue_3.3", changedSlider.value);
                    Debug.Log("sliderValue_0.0");

                }
                else if (giftItemCount == 4)
                {

                    PlayerPrefs.SetFloat("sliderValue_4.3", changedSlider.value);
                    Debug.Log("sliderValue_0.1");


                }
                else if (giftItemCount == 5)
                {

                    PlayerPrefs.SetFloat("sliderValue_5.3", changedSlider.value);
                    Debug.Log("sliderValue_0.2");


                }

        
                parcentageBoxs[3].text = changedSlider.value.ToString();
          
                break;
            case 4:
                Debug.Log("slider" + sliderIndex + " " + "value is " + changedSlider.value);
                if (changedSlider.value > 3 && changedSlider.value < 97)
                {
                    text_percentageSlider4.SetActive(true);
                }
                else
                {
                    text_percentageSlider4.SetActive(false);
                }
                if (giftItemCount == 3)
                {

                    PlayerPrefs.SetFloat("sliderValue_3.4", changedSlider.value);
                    Debug.Log("sliderValue_0.0");

                }
                else if (giftItemCount == 4)
                {

                    PlayerPrefs.SetFloat("sliderValue_4.4", changedSlider.value);
                    Debug.Log("sliderValue_0.1");


                }
                else if (giftItemCount == 5)
                {

                    PlayerPrefs.SetFloat("sliderValue_5.4", changedSlider.value);
                    Debug.Log("sliderValue_0.2");


                }

             
                parcentageBoxs[4].text = changedSlider.value.ToString();
            
                break;
            case 5:
                Debug.Log("slider" + sliderIndex + " " + "value is " + changedSlider.value);
                if (changedSlider.value > 3 && changedSlider.value < 97)
                {
                    text_percentageSlider5.SetActive(true);
                }
                else
                {
                    text_percentageSlider5.SetActive(false);
                }
                if (giftItemCount == 3)
                {

                    PlayerPrefs.SetFloat("sliderValue_3.5", changedSlider.value);
                    Debug.Log("sliderValue_0.0");

                }
                else if (giftItemCount == 4)
                {

                    PlayerPrefs.SetFloat("sliderValue_4.5", changedSlider.value);
                    Debug.Log("sliderValue_0.1");


                }
                else if (giftItemCount == 5)
                {

                    PlayerPrefs.SetFloat("sliderValue_5.5", changedSlider.value);
                    Debug.Log("sliderValue_0.2");


                }

              ;
                parcentageBoxs[5].text = changedSlider.value.ToString();
               
                break;
            case 6:
                if (changedSlider.value > 3 && changedSlider.value < 97)
                {
                    text_percentageSlider6.SetActive(true);
                }
                else
                {
                    text_percentageSlider6.SetActive(false);
                }
                if (giftItemCount == 3)
                {

                    PlayerPrefs.SetFloat("sliderValue_3.6", changedSlider.value);
                    Debug.Log("sliderValue_0.0");

                }
                else if (giftItemCount == 4)
                {

                    PlayerPrefs.SetFloat("sliderValue_4.6", changedSlider.value);
                    Debug.Log("sliderValue_0.1");


                }
                else if (giftItemCount == 5)
                {

                    PlayerPrefs.SetFloat("sliderValue_5.6", changedSlider.value);
                    Debug.Log("sliderValue_0.2");


                }

               
                parcentageBoxs[6].text = changedSlider.value.ToString();
                break;


        }





    }
    #region 
    public void LooseparcentagesBox()
    {

        string inputText = parcentageBoxs[0].text;


        if (int.TryParse(inputText, out selectedParcentages))
        {
            Debug.Log("selected box" + selectedParcentages);
            sliders[0].value = selectedParcentages;
           
            percentValues[0] = selectedParcentages;
            sliderValue[0] = selectedParcentages;
            CalculateParcentThreshHold();

           


        }
        else
        {
            Debug.Log("Invalid input! Please enter a valid integer.");

        }

    }
    public void parcentagesBox_0() 
    {
        
        string inputText = parcentageBoxs[1].text;
       
       
        if (int.TryParse(inputText, out selectedParcentages))
        {
            Debug.Log("selected box" + selectedParcentages);
            sliders[1].value =selectedParcentages;
            percentValues[1]= selectedParcentages;
            sliderValue[1] = selectedParcentages;
            CalculateParcentThreshHold();


        }
        else
        {
            Debug.Log("Invalid input! Please enter a valid integer.");
        }

    }
    public void parcentagesBox_1()
    {
        
        string inputText = parcentageBoxs[2].text;


        if (int.TryParse(inputText, out selectedParcentages))
        {
            Debug.Log("selected box" + selectedParcentages);
            sliders[2].value = selectedParcentages;
            percentValues[2] = selectedParcentages;
            sliderValue[2] = selectedParcentages;
            CalculateParcentThreshHold();

        }
        else
        {
            Debug.Log("Invalid input! Please enter a valid integer.");
        }

    }
    public void parcentagesBox_2()
    {
        
        string inputText = parcentageBoxs[3].text;


        if (int.TryParse(inputText, out selectedParcentages))
        {
            Debug.Log("selected box" + selectedParcentages);
            sliders[3].value = selectedParcentages;
            percentValues[3] = selectedParcentages;
            sliderValue[3] = selectedParcentages;
            CalculateParcentThreshHold();
        }
        else
        {
            Debug.Log("Invalid input! Please enter a valid integer.");
        }

    }
    public void parcentagesBox_3()
    {
        //Debug.Log("box number" + whichBox);
        string inputText = parcentageBoxs[4].text;


        if (int.TryParse(inputText, out selectedParcentages))
        {
            Debug.Log("selected box" + selectedParcentages);
            sliders[4].value = selectedParcentages;
            percentValues[4] = selectedParcentages;
            sliderValue[4] = selectedParcentages;
            CalculateParcentThreshHold();
        }
        else
        {
            Debug.Log("Invalid input! Please enter a valid integer.");
        }

    }
    public void parcentagesBox_4()
    {
        
        string inputText = parcentageBoxs[5].text;


        if (int.TryParse(inputText, out selectedParcentages))
        {
            Debug.Log("selected box" + selectedParcentages);
            sliders[5].value = selectedParcentages;
            percentValues[5] = selectedParcentages;
            sliderValue[5] = selectedParcentages;
            CalculateParcentThreshHold();
        }
        else
        {
            Debug.Log("Invalid input! Please enter a valid integer.");
        }

    }
    public void winingSoundPlay()
    {
        AudioSource.PlayOneShot(winingClip);   
    }

    public void CalculateParcentThreshHold() 
    {
        sum = 0;
        for (int i = 0; i < percentValues.Length; i++) 
        {
           
            sum += percentValues[i];
            totalThreshold.text=sum.ToString();

            if (sum == 100)
            {

                parcentagesOverFlow.SetActive(false);


            }
            else if (sum > 100 && !isActivateOnce )
            {

                isActivateOnce = true;
                StartCoroutine(LockSlidersAtCurrentValue());


            }
            else if (sum < 100) 
            {
               // UnlockSlidersAtCurrentValue();



            }
           


        }

      

    }


    #endregion


    #region 

    public IEnumerator LockSlidersAtCurrentValue() 
    {

        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < sliders.Length; i++)
        {
           // sliders[i].maxValue= sliders[i].value;

            sliders[i].GetComponent<Slider>().interactable=false;
        }

        yield return new WaitForSeconds(3.5f);
        parcentagesOverFlow.SetActive(true);

        StartCoroutine(UnlockSlidersAtCurrentValue());

    }
    public IEnumerator UnlockSlidersAtCurrentValue()
    {
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < sliders.Length; i++)
        {

            sliders[i].GetComponent<Slider>().interactable = true;
        }


    }





    #endregion

    #region 

    public void rollingSpeedUpdateHandler(float value)
    {
        
        if (value == 1)
        {
         
            PlayerPrefs.SetInt("rotationSpeed", rotationSpeed_1);
            moveSpeed = rotationSpeed_1;
        }
        else if (value == 2)
        {
         
            PlayerPrefs.SetInt("rotationSpeed", rotationSpeed_2);
            moveSpeed = rotationSpeed_2;

        }
        else 
        {
            PlayerPrefs.SetInt("rotationSpeed", rotationSpeed_3);
            moveSpeed = rotationSpeed_3;


        }

        if (value >= 2)
        {
            text_RollingSpeedSlider.SetActive(true);

        }
        else
        {
            text_RollingSpeedSlider.SetActive(false);
        }


    }

    public void rollingTimeUpdateHandler(float value)
    {   
        if(value == 1)
        {
            PlayerPrefs.SetInt("rotationTime", 6);
            RollerManager.Instance._rollers[0].GetComponent<Roller>().spinTime=6; 
            RollerManager.Instance._rollers[1].GetComponent<Roller>().spinTime = 6;
            RollerManager.Instance._rollers[2].GetComponent<Roller>().spinTime = 6;

        }
        else if (value == 2)
        {

            PlayerPrefs.SetInt("rotationTime", 7);
            RollerManager.Instance._rollers[0].GetComponent<Roller>().spinTime = 8;
            RollerManager.Instance._rollers[1].GetComponent<Roller>().spinTime = 8;
            RollerManager.Instance._rollers[2].GetComponent<Roller>().spinTime = 8;

        }
        else
        {
            PlayerPrefs.SetInt("rotationTime", 10);

           
            RollerManager.Instance._rollers[0].GetComponent<Roller>().spinTime = 10;
            RollerManager.Instance._rollers[1].GetComponent<Roller>().spinTime = 10;
            RollerManager.Instance._rollers[2].GetComponent<Roller>().spinTime = 10;

        }
   
        if (value >= 2)
        {
            text_RollingTimeSlider.SetActive(true);
            
        }
        else
        {
            text_RollingTimeSlider.SetActive(false);
        }

        
    }

    public void rollingItemUpdateHandler(float value)
    {
   
        if(value == 1)
        {
            isActivateOnce = false;
            PlayerPrefs.SetInt("gift", 3);
            giftItemCount = 3;

            belowBox[0].SetActive(true);
            belowBox[1].SetActive(false);
            belowBox[2].SetActive(false);
            sliders[4].gameObject.SetActive(false);
            sliders[5].gameObject.SetActive(false);

            for(int i = 0; i < sliderImages.Length; i++)
            {
                sliderImages[i].SetActive(false);
            }
           
            sliders[4].value = 0;
            sliders[5].value = 0;



        }
        else if(value == 2)
        {
            isActivateOnce = false;

            PlayerPrefs.SetInt("gift", 4);
            giftItemCount = 4;

            belowBox[0].SetActive(false);
            belowBox[1].SetActive(true);
            belowBox[2].SetActive(false);
            sliders[4].gameObject.SetActive(true);
            sliders[5].gameObject.SetActive(false);

            sliderImages[0].SetActive(true);
            sliderImages[1].SetActive(true);
            sliderImages[2].SetActive(false);
            sliderImages[3].SetActive(false);

          
            sliders[5].value = 0;
        }
        else if ( value == 3)
        {
            isActivateOnce = false;

            PlayerPrefs.SetInt("gift", 5);
            giftItemCount = 5;

            belowBox[0].SetActive(false);
            belowBox[1].SetActive(false);
            belowBox[2].SetActive(true);
            sliders[4].gameObject.SetActive(true);
            sliders[5].gameObject.SetActive(true);

            for (int i = 0; i < sliderImages.Length; i++)
            {
                sliderImages[i].SetActive(true);
            }

           



        }
        RollerManager.Instance.ItemChange((int)value);
        itemCount = (int)value+2;

        if (value >= 2)
        {
            text_RollingItemSlider.SetActive(true);

        }
        else
        {
            text_RollingItemSlider.SetActive(false);
        }
        
    }

    #endregion


    public void particleHandler(float value)
    {
        particleStyleMode = (int)value;

        if (value == 1)
        {
            PlayerPrefs.SetInt("particles", 1);

        }
        else 
        {
            PlayerPrefs.SetInt("particles", 2);

        }
    }
     
    public int getParticleStyleMode()
    {
        return particleStyleMode;
    }

    public void resetHandler(){
        isActivateOnce = false;
        for(int i=0;i<6;i++){
            Debug.Log("before reset  "+ sliders[i].value);
            sliderValue[i] = 0;
            sliders[i].value = 0;
        }
        float[] s = getSliderValue();
        
    }

    public void setSlider(int i)
    {
        sliderValue[i] = sliders[i].value;
        float remainingValue = overAllpercentage - sliderValue[i];
        StartCoroutine(SetValuesToOtherSlider(remainingValue));
    
    }

    public IEnumerator SetValuesToOtherSlider(float remainingValues) 
    {      
        yield return new WaitForSeconds(0.2f);
        Debug.Log("enter slider");

    }

    public float[] getSliderValue()
    {
        Debug.Log("getSliderValue");
        
        return sliderValue;
    }

    public float getRollingTime()
    {
       
        Debug.Log("getRollingTime "+ rollingTime);
        return rollingTime;
    }

    public float getRollingSpeed()
    {
       
        return ( 3000+rollingSpeed);
    }

    public int getItemCount()
    {

        return itemCount;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
       // PlayerPrefs.SetInt("Quit", 50);
    }

    public void SetValue()
    {

        
        float getValue_3_0 = PlayerPrefs.GetFloat("sliderValue_3.0");
        float getValue_4_0 = PlayerPrefs.GetFloat("sliderValue_4.0");
        float getValue_5_0 = PlayerPrefs.GetFloat("sliderValue_5.0");

        float getValue_3_1 = PlayerPrefs.GetFloat("sliderValue_3.1");
        float getValue_4_1 = PlayerPrefs.GetFloat("sliderValue_4.1");
        float getValue_5_1 = PlayerPrefs.GetFloat("sliderValue_5.1");

        float getValue_3_2 = PlayerPrefs.GetFloat("sliderValue_3.2");
        float getValue_4_2 = PlayerPrefs.GetFloat("sliderValue_4.2");
        float getValue_5_2 = PlayerPrefs.GetFloat("sliderValue_5.2");

        float getValue_3_3 = PlayerPrefs.GetFloat("sliderValue_3.3");
        float getValue_4_3 = PlayerPrefs.GetFloat("sliderValue_4.3");
        float getValue_5_3 = PlayerPrefs.GetFloat("sliderValue_5.3");

        float getValue_3_4 = PlayerPrefs.GetFloat("sliderValue_3.4");
        float getValue_4_4 = PlayerPrefs.GetFloat("sliderValue_4.4");
        float getValue_5_4 = PlayerPrefs.GetFloat("sliderValue_5.4");


        float getValue_3_5 = PlayerPrefs.GetFloat("sliderValue_3.5");
        float getValue_4_5 = PlayerPrefs.GetFloat("sliderValue_4.5");
        float getValue_5_5 = PlayerPrefs.GetFloat("sliderValue_5.5");

        if (giftItemCount == 3)
        {
            Debug.Log("1000.1");
            sliderValue[0] = getValue_3_0;
            sliderValue[1] = getValue_3_1;
            sliderValue[2] = getValue_3_2;
            sliderValue[3] = getValue_3_3;
            sliderValue[4] = 0;
            sliderValue[5] = 0;


        }
        else if (giftItemCount == 4)
        {
            Debug.Log("1000.2");
            sliderValue[0] = getValue_4_0;
            sliderValue[1] = getValue_4_1;
            sliderValue[2] = getValue_4_2;
            sliderValue[3] = getValue_4_3;
            sliderValue[4] = getValue_4_4;
            sliderValue[5] = 0;
        }
        else if (giftItemCount == 5)
        {
            Debug.Log("1000.3");
            sliderValue[0] = getValue_5_0;
            sliderValue[1] = getValue_5_1;
            sliderValue[2] = getValue_5_2;
            sliderValue[3] = getValue_5_3;
            sliderValue[4] = getValue_5_4;
            sliderValue[5] = getValue_5_5;
        }

    }


}

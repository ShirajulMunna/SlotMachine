using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//using UnityEngine.UI;
//using UnityEngine.UIElements;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider _sliders1;
    [SerializeField] private Slider _sliders2;
    [SerializeField] private Slider _sliders3;
    [SerializeField] private Slider _sliders4;
    [SerializeField] private Slider _sliders5;
    [SerializeField] private Slider _sliders6;

    [SerializeField] private TextMeshProUGUI _sliderTexts1;
    [SerializeField] private TextMeshProUGUI _sliderTexts2;
    [SerializeField] private TextMeshProUGUI _sliderTexts3;
    [SerializeField] private TextMeshProUGUI _sliderTexts4;
    [SerializeField] private TextMeshProUGUI _sliderTexts5;
    [SerializeField] private TextMeshProUGUI _sliderTexts6;

    [SerializeField] private Button btn;

    void Start()
    {
        _sliders1.value = 50;
        _sliders2.value = 100;
        _sliders3.value = 55;
        _sliders4.value = 45;
        _sliders5.value = 30;
        _sliders6.value = 90;
        _sliderTexts1.text = _sliders1.value + "%";
        _sliderTexts2.text = _sliders2.value + "%";
        _sliderTexts3.text = _sliders3.value + "%";
        _sliderTexts4.text = _sliders4.value + "%";
        _sliderTexts5.text = _sliders5.value + "%";
        _sliderTexts6.text = _sliders6.value + "%";

        _sliders1.onValueChanged.AddListener((v) =>
        {
            _sliderTexts1.text = v.ToString("0") + "%";
        });

        _sliders2.onValueChanged.AddListener((v) =>
        {
            _sliderTexts2.text = v.ToString("0") + "%";
        });

        _sliders3.onValueChanged.AddListener((v) =>
        {
            if(v>3.0f && v < 97.0f)
            {
                _sliderTexts3.text = v.ToString("0") + "%";
            }
            else
            {
                _sliderTexts3.text = "";
            }
            
        });


        _sliders4.onValueChanged.AddListener((v) =>
        {
            _sliderTexts4.text = v.ToString("0") + "%";
        });

        _sliders5.onValueChanged.AddListener((v) =>
        {
            _sliderTexts5.text = v.ToString("0") + "%";
        });

        _sliders6.onValueChanged.AddListener((v) =>
        {
            _sliderTexts6.text = v.ToString("0") + "%";
        });

        btn.onClick.AddListener(() =>
        {
            Debug.Log("Slider 1 ="+ _sliders1.value);
            Debug.Log("Slider 2 =" + _sliders2.value);
            Debug.Log("Slider 3 =" + _sliders3.value);
            Debug.Log("Slider 4 =" + _sliders4.value);
            Debug.Log("Slider 5 =" + _sliders5.value);
            Debug.Log("Slider 6 =" + _sliders6.value);

        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*public int[] getSetting()
    {
        return [];
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Tweening : MonoBehaviour
{
    
    void Start()
    {
       // GetComponent<RectTransform>().DOMoveY(-8.00f, 0.1f).SetEase(Ease.InBounce);
        GetComponent<RectTransform>().DOLocalMoveY(-8.00f,0.1f).SetEase(Ease.InBounce);

    }

    
   
}

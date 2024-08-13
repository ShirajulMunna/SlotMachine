using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JGM.Game.Patterns
{
    public class LinePatternChecker : ILinePatternChecker
    {
        
        public ILineResult GetResultFromLine(in List<int> itemsInsideLine, GameObject failWindow, GameObject winWindow, GameObject[] particle, Sprite[] sprites, int particleStyleMode)
        {
            var lineResult = new LineResult();

            for (int i = 0; i < itemsInsideLine.Count; ++i)
            {
                if (lineResult.FirstItemTypeFoundInLine == -1)
                {
                    lineResult.FirstItemTypeFoundInLine = itemsInsideLine[i];
                    lineResult.ItemCount++;
                }
                else if (itemsInsideLine[i] == lineResult.FirstItemTypeFoundInLine)
                {
                    lineResult.ItemCount++;
                }
                else
                {
                    lineResult.ItemCount=0; ;
                    break;

                }
                Debug.Log("window detection");
                if (lineResult.ItemCount < 3)
                {
                    winWindow.SetActive(false);
                    failWindow.SetActive(true);
                }
                else if (lineResult.ItemCount == 3)
                {
                    // winWindow.GetComponent<Image>().sprite = null;
                    winWindow.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = sprites[itemsInsideLine[0]];
                    failWindow.SetActive(false);
                    winWindow.SetActive(true);
                    GameManager.Instance.winingSoundPlay();
                    particle[particleStyleMode-1].SetActive(true);

                    Debug.Log("lineResult.ItemCount" + lineResult.ItemCount);
                }
                Debug.Log("lineResult.ItemCount" + lineResult.ItemCount);
            }
            

            return lineResult;
        }
    }
}
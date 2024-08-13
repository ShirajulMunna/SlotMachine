using JGM.Game.Audio;
using JGM.Game.Libraries;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace JGM.Game.Rollers
{
    public class Roller : MonoBehaviour
    {
        public static Roller instance;
        public float lerpSpeed = 1.0f;  // Speed of interpolation (0 to 1)

        private float journeyLength;    // Distance between startMarker and endMarker
        private float startTime;
        int current_obj;
        private string Name 
        { get { return name; }
          set { name = value; } 
        }
     
        //public static Roller Instance;

        public float[] rollerItemProbability;

        public bool IsSpinning { get; private set; }

        public List<RollerItem> _items;

        [Inject] private IAudioService _audioService;
        [Inject] private RollerItemFactory _rollerItemFactory;

        private const float _minSpinTimeInSeconds = 2f;
        private const float _maxSpinTimeInSeconds = 2f;
        private const float _centerItemSpeed = 4f;

       
        private  float _itemSpinSpeed = 500;
        private const float _startingItemYPosition = -240.0f;
        private const float _spacingBetweenItems = 228f;
        private const float _itemBottomLimit = -355f;

        private bool _centerItemsOnScreen = false;

        public bool increasedSpeed=true;
        public int spinTime;
        public float totalTime { set; get; }

        public void Initialize(RollerSequenceLibrary itemSequence, SpriteLibrary spriteAssets)
        {
            _items = new List<RollerItem>();

            InstantiateAndAddRollerItemsToList(itemSequence, spriteAssets);
        }

        private void Start()
        {
            _itemSpinSpeed = PlayerPrefs.GetInt("rotationSpeed");
            spinTime= PlayerPrefs.GetInt("rotationTime", 6);
        }



        private void Update()
        {
            if (!IsSpinning)
            {
                CenterItemsOnScreenIfNecessary();
                
                totalTime = 0;
                return;
            }
       

            SpinItems();
        }

        private void Awake()
        {
            instance = this;
        }
        int index;
        public void StartSpin()
        {
            
            IsSpinning = true;
        }
      
       
        public void StartSpinCountdown(string rollerName,float rand, int noMatchRand)
        {

            float currentSpinTmeInSeconds = 0.5f;

            if (rollerName == "roller_1")
            {
                currentSpinTmeInSeconds = spinTime - 3;
            }
            else if (rollerName == "roller_2")
            {
                currentSpinTmeInSeconds = 1.5f;
            }
            else
            {
                currentSpinTmeInSeconds = 1.5f;
            }

            StartCoroutine(StopSpinAfterDelay(currentSpinTmeInSeconds, rand, noMatchRand));
        }

        public void MoveFirstItemToTheBack()
        {
            var firstItem = _items[0];
            _items.Add(firstItem);
            _items.RemoveAt(0);
        }

        public Vector3 GetSpacingBetweenItems()
        {
            return Vector3.up * _spacingBetweenItems;
        }

        public Vector3 GetLastItemLocalPosition()
        {
            return _items[_items.Count - 1].transform.localPosition;
        }

        public void GetRollerItemsOnScreen(out List<int> itemsOnScreen)
        {
            itemsOnScreen = new List<int>();
            for (int i = RollerManager.NumberOfRowsInGrid - 1; i >= 0; --i)
            {
                itemsOnScreen.Add((int)_items[i].Type);
            }
        }

        private void InstantiateAndAddRollerItemsToList(RollerSequenceLibrary itemSequence, SpriteLibrary spriteLoader)
        {
            
            for (int i = 0; i < itemSequence.Assets.Length; ++i)
            {
                var item = _rollerItemFactory.Create();
                item.transform.SetParent(transform);
                var itemLocalPosition = Vector3.up * _startingItemYPosition + (i * GetSpacingBetweenItems());
                item.transform.localPosition = itemLocalPosition;
                item.transform.localScale = Vector3.one;
                var itemType = itemSequence.Assets[i];
                
                var itemSprite = spriteLoader.Assets[(int)itemType];
                item.Initialize(this, itemType, itemSprite, _itemSpinSpeed, _itemBottomLimit);
                _items.Add(item);
            }
        }
        public float speedY = 1;
        int revSpeedY = 0;
        public bool startDecrese;
        public int totalSpeed;

        private void SpinItems()
        {
           
            totalTime += Time.deltaTime;
            Debug.Log("Total time " + " " + totalTime);


            for (int i = 0; i < _items.Count; ++i)
            {                         

                _items[i].Spin();

            }
        }

        private IEnumerator StopSpinAfterDelay(float delayInSeconds, float rand, int noMatchRand)
        {
            int itemCount = GameManager.Instance.getItemCount();
            rollerItemProbability = GameManager.Instance.getSliderValue();
            for(int i=0; i<6; i++)
            {
                Debug.Log("ewwwwww "+ rollerItemProbability[i] + " index "+i);
            }

            int noMatchProbability = 0;
            bool anyOneHundredPercentSliderFound = false;
            float sum = 0;
            for (int i = 0; i < 6; i++)
            {
                if (i <= itemCount)
                {
                    if (rollerItemProbability[i] == 100)
                    {
                        anyOneHundredPercentSliderFound = true;
                        Debug.Log("anyOneHundredPercentSliderFound");
                    }
                    sum += rollerItemProbability[i];
                    Debug.Log("Probability sum = "+ sum + "rollerItemProbability" + rollerItemProbability[i]);
                }
                else
                {
                    rollerItemProbability[i] = 0;
                }
                
            }

            if (anyOneHundredPercentSliderFound)
            {
                noMatchProbability = 0;
                Debug.Log("Probability psum = TRUE");
            }
            else
            {
                noMatchProbability = noMatchRand;
                sum = sum + noMatchProbability;
            }

            float p_sum = 0;
           
            
            float[] vals = new float[6];
            for (int i = 1; i <=itemCount; i++)
            {
              
                vals[i] = ((rollerItemProbability[i] / sum));
                
            }

            if(noMatchProbability != 0)
            {
                vals[0] = (1- vals.Sum());
            }
            else
            {
                vals[0] = 0;
            }

            string[] s = vals.Select(x => x.ToString()).ToArray();
            Debug.Log("ssssssssssss xx" + string.Join(" ", s) +" rand  "+rand +" nomatchrand" + noMatchRand);

            RollerItemType a = RollerItemType.None;
            for (int i = 0; i < 6; i++)
            {

                p_sum += vals[i];
                Debug.Log("Probability psum = " + p_sum + " rand =" + rand +"No match "+ noMatchProbability+ "count = "+itemCount + "Vals[5]"+ vals[5]);
                if (p_sum >rand )
                {
                    if (i == 1)
                    {
                        a = RollerItemType.Watch;
                    }
                    else if (i == 2)
                    {
                        a = RollerItemType.Camera;
                    }
                    else if (i == 3)
                    {
                        a = RollerItemType.Laptop;
                    }
                    else if (i == 4)
                    {
                        a = RollerItemType.Bag;
                    }
                    else if (i == 5)
                    {
                        
                        a = RollerItemType.Iphone;
                    }
                    else 
                    {
                        a = RollerItemType.None;
                        Debug.Log("ssssssssssss xx else executed a=NONE");
                    }
                    
                    break;
                }
            }
            yield return new WaitForSeconds(delayInSeconds);
           
            
            if(a != RollerItemType.None)
            {
                yield return new WaitWhile(() => _items[1].Type != a);
            }
            else
            {
                yield return new WaitWhile(() => _items[1].Type == a);
            }

            IsSpinning = false;
            _centerItemsOnScreen = true;
            _audioService.Play("Stop Roller");
            // totalTime = 0;
          
            Debug.Log("rollername = " + name);
            
            }

       

        private void CenterItemsOnScreenIfNecessary()
        {
            if (_centerItemsOnScreen)
            {
                Vector3 localPosition = Vector3.zero;
                for (int i = 0; i < _items.Count; ++i)
                {
                    localPosition = Vector3.up * _startingItemYPosition + (i * GetSpacingBetweenItems());
                    _items[i].transform.localPosition = Vector3.Lerp(_items[i].transform.localPosition, localPosition, Time.deltaTime * _centerItemSpeed);
                }
                if (_items[_items.Count - 1] && Mathf.Abs(_items[_items.Count - 1].transform.localPosition.y - localPosition.y) < 0.01f)
                {
                    _centerItemsOnScreen = false;
                }
            }
        }


        public void RollingItemChange(RollerSequenceLibrary itemSequence, SpriteLibrary spriteLoader)
        {

            for (int i = 0; i < itemSequence.Assets.Length; ++i)
            {
                
                var itemType = itemSequence.Assets[i];
                Debug.Log("ItemType: " + itemType);
                var itemSprite = spriteLoader.Assets[(int)itemType];
                
                    _items[i].setImage(itemSprite);
                    _items[i].setType(itemType);
                              
            }
        }
    }
}
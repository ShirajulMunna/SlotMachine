using JGM.Game.Audio;
using JGM.Game.Events;
using JGM.Game.Libraries;
using JGM.Game.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Grid = JGM.Game.Patterns.Grid;

namespace JGM.Game.Rollers
{
    public class RollerManager : MonoBehaviour
    {
        public static RollerManager Instance;
        [Inject] private IAudioService _audioService;
        [Inject] private IEventTriggerService _eventTriggerService;
        [Inject] private RollerFactory _rollerFactory;
        [Inject] private RollerSequencesLibrary _rollerSequencesLibrary;
        [Inject] public SpriteLibrary _spriteAssets;

        public Button settingButton;

        public Roller[] _rollers;
        private IGrid _gridOfStoppedRollerItemsOnScreen;

        private const float _startingRollerXPosition = -100f;
        private const float _spacingBetweenRollers = 100.0f;
        private const float _delayBetweenRollersInSeconds = 0.3f;
       

        public const int NumberOfRowsInGrid = 3;
        public const int NumberOfColumnsInGrid = 3;

        private void Start()
        {
            _rollers = new Roller[NumberOfColumnsInGrid];
            _gridOfStoppedRollerItemsOnScreen = new Grid(NumberOfRowsInGrid, NumberOfColumnsInGrid);
            InstantiateAndAddRollersToList();
        } 
       
        public void StartSpin()
        {
            StartCoroutine(SpinRollers());
        }

        private void Awake()
        {
            Instance = this;
        }

        public void ResetGrid()
        {
            _gridOfStoppedRollerItemsOnScreen.ResetGridValues();
        }

        public void InstantiateAndAddRollersToList()
        {
            for (int i = 0; i < _rollers.Length; ++i)
            {
                var roller = _rollerFactory.Create();
                roller.transform.SetParent(transform);
                var rollerLocalPosition = Vector3.right * (_startingRollerXPosition + (i * _spacingBetweenRollers));
                roller.transform.localPosition = rollerLocalPosition;
                roller.transform.localScale = new Vector3(.35f,.35f,1f);
                roller.Initialize(_rollerSequencesLibrary.Assets[i], _spriteAssets);
                _rollers[i] = roller;
                _rollers[i].name = "roller_"+(i+1);
            }
        }

        public void ItemChange(int val)
        {
            Debug.Log("wwwww "+val);
            int p;
            if (val == 1)
            {
                p = 0;
            }else if (val == 2)
            {
                p = 3;
            }
            else
            {
                p = 6;
            }
            for (int i = 0; i < _rollers.Length; ++i)
            {
                _rollers[i].RollingItemChange(_rollerSequencesLibrary.Assets[p+i], _spriteAssets);
            }
        }

        private float GenerateNumber()
        {
            float randomValue = Random.value; 
            return randomValue;
        }


        private IEnumerator SpinRollers()
        {
            GameObject.Find("Collider_1").GetComponent<BoxCollider2D>().enabled = true;
           


            settingButton.enabled = false;
           // _audioService.Play("Spin Roller", true);
            for (int i = 0; i < _rollers.Length; ++i)
            {
                _rollers[i].StartSpin();
                yield return new WaitForSeconds(_delayBetweenRollersInSeconds);
            }
           
            float rand= GenerateNumber();
          

            int noMatchRand =(int) GameManager.Instance.sliderValue[0];
            Debug.Log("random" + noMatchRand);

            for (uint i = 0; i < _rollers.Length; ++i)
            {
                _rollers[i].StartSpinCountdown(_rollers[i].name,rand, noMatchRand);
                yield return new WaitWhile(() => _rollers[i].IsSpinning);
                
                _rollers[i].GetRollerItemsOnScreen(out List<int> itemsOnScreen);
                
               
                _gridOfStoppedRollerItemsOnScreen.SetColumnValues(i, itemsOnScreen);
            }
            _audioService.Stop("Spin Roller");
            yield return new WaitForSeconds(2f);
           
            _eventTriggerService.Trigger("Check Spin Result", new SpinResultData(_gridOfStoppedRollerItemsOnScreen));
            settingButton.enabled = true;
            

        }
    }

    
}
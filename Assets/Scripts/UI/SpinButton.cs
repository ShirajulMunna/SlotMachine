using JGM.Game.Audio;
using JGM.Game.Events;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;

namespace JGM.Game.UI
{
    [RequireComponent(typeof(Button))]
    public class SpinButton : MonoBehaviour
    {
        [Inject] private IAudioService _audioService;
        [Inject] private IEventTriggerService _eventTriggerService;
        public RectTransform startGameTxt;

        private Button _spinButton;
        public GameObject spark;
        public GameObject spark_2;
        public AudioClip gameStart;
        private AudioSource _audioSource;


        private void Awake()
        {
            _spinButton = GetComponent<Button>();
            _audioSource = GetComponent<AudioSource>();
        }

        public void TriggerStartSpinEvent() 
        {
            //_audioService.Play("Press Button");
            StartCoroutine(SendStartSpinEventAfterAudioFinishedPlaying());
        }

        private IEnumerator SendStartSpinEventAfterAudioFinishedPlaying()
        {
            yield return new WaitWhile(() => _audioService.IsPlaying("Press Button"));
            startGameTxt.DOLocalMoveX(4.00f, 0.1f).SetEase(Ease.InElastic).OnComplete(() => {
                spark.SetActive(true);
                spark_2.SetActive(true);
                _audioSource.PlayOneShot(gameStart);

                startGameTxt.DOShakePosition(duration: 1f, strength: 10f, vibrato: 10).OnComplete(() => {

                _eventTriggerService.Trigger("Start Spin");

                    Invoke("AfterStartAnim", 0.2f);

                });
              



            });
         
        }

        public void AfterStartAnim() 
        {
            startGameTxt.DOLocalMoveX(530f, 0.1f).SetEase(Ease.InBounce);
            spark.SetActive(false);
            spark_2.SetActive(false);



        }

        public void SetButtonInteraction(bool makeInteractable)
        {
            _spinButton.interactable = makeInteractable;
        }
    }
}
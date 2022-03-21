using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EasyClap
{
    public class BerkeLevelHUD : MonoBehaviour
    {
        public Image TapImage;
        public Image HandImage;
        public Image NextLevelPanel;
        
        public GameObject RetryButton;

        public ClonePlayerController playerController;

        private bool firstTouch = true;
        
        public static BerkeLevelHUD instance;
        
        // Start is called before the first frame update
        
        private void Awake()
        {
            Time.timeScale = 0f;
            instance = this;
            RetryButton.SetActive(false);
        }
        
        void Start()
        {
            NextLevelPanel.gameObject.SetActive(false);
            RetryButton.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && firstTouch)
            {
                StartCoroutine(DecreaseAlpha());
                firstTouch = false;
                Time.timeScale = 1f;
            }
        }

        public void ShowNextLevelButton()
        {
            StartCoroutine(NextLevelButton());
        }

        public IEnumerator NextLevelButton()
        {
            var PanelCounter = 0f;

            NextLevelPanel.gameObject.SetActive(true);
            
            while (PanelCounter < 1)
            {
                NextLevelPanel.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, PanelCounter);
                PanelCounter += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
        
        
        public IEnumerator DecreaseAlpha()
        {
            var alpha = 1f;

            while (alpha>0f)
            {
                alpha -= Time.deltaTime * 2f;
                HandImage.color = new Color(HandImage.color.r,HandImage.color.g,HandImage.color.b,alpha);
                TapImage.color = new Color(TapImage.color.r,TapImage.color.g,TapImage.color.b,alpha);
                yield return new WaitForEndOfFrame();
            }
        }
        
        public void ShowRetryButton()
        {
            RetryButton.SetActive(true);
        }

        public void Retry()
        {
            var SceneIndex = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(SceneIndex);
        }
    }
}

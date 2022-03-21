using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EasyClap
{

	public class LevelHUD : MonoBehaviour
	{
		// private float ImageInterval;

		public static LevelHUD instance;

		public GameObject RetryButton;
		public Image TapImage;
		public Image HandImage;
		public Image FeedBackText;
		public Image NextLevelPanel;
		private DynamicJoystick dynamicJoystick;
		private Swatter swatter;

		private void Awake()
		{
			instance = this;
			dynamicJoystick = GameObject.FindObjectOfType<DynamicJoystick>();
			swatter = GameObject.FindObjectOfType<Swatter>();
		}

		private void Start()
		{
			if (ProgressManager.instance.BugCount < 0)
			{
				ProgressManager.instance.BugCount = 0;
			}

			// ImageInterval = 1f / ProgressManager.instance.BugCount;
			NextLevelPanel.gameObject.SetActive(false);
			RetryButton.SetActive(false);
		}

		public void StartFeedBackText()
		{
			StartCoroutine(FeedBackTextAnim());
		}

		IEnumerator FeedBackTextAnim()
		{

			var counter = 0f;

			while (counter < 1)
			{
				FeedBackText.color = new Color(1, 1, 1, counter);
				counter += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			
			yield return new WaitForSeconds(0.5f);

			counter = 0f;

			while (counter < 1)
			{
				counter += Time.deltaTime;
				FeedBackText.color = new Color(1, 1, 1, 1-counter);
				yield return new WaitForEndOfFrame();
			}
			
			
			
		}
		public IEnumerator NextLevelAnim()
		{
			dynamicJoystick.gameObject.SetActive(false);
			swatter.gameObject.SetActive(false);
			
			var PanelCounter = 0f;
			
			NextLevelPanel.gameObject.SetActive(true);

			while (PanelCounter < 1)
			{
				NextLevelPanel.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, PanelCounter);
				PanelCounter += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}

		}


		public void StartFadeTapToPlay()
		{
			StartCoroutine(FadeTapToPlay());
		}
		
		
		public IEnumerator FadeTapToPlay()
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
		

		public void NextLevelLooping()
		{
			Debug.Log("Current Scene=" + SceneManager.GetActiveScene().buildIndex);

			var SceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
			
			PlayerPrefs.SetInt("Level", SceneIndex);

			SceneIndex = SceneIndex % SceneManager.sceneCountInBuildSettings;

			if (SceneIndex.Equals(0))
			{
				SceneIndex = 1;
			}

			Debug.Log("Next Scene=" + SceneIndex);

			SceneManager.LoadScene(SceneIndex);
		}

		public void ActivateRetryButton()
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

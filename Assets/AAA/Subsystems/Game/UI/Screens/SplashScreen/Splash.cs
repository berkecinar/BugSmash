using System.Collections;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EasyClap
{

	public class Splash : MonoBehaviour
	{
		public CanvasGroup LogoPanel;
		public float FadeInDuration = 0.4f;
		public float WaitDuration = 2f;
		public float FadeOutDuration = 0.4f;

		public Ease FadeInEase = Ease.Linear;
		public Ease FadeOutEase = Ease.Linear;

		private IEnumerator Start()
		{
			// Logo fade in
			LogoPanel.alpha = 0f;
			yield return DOTween.To(() => LogoPanel.alpha, value => LogoPanel.alpha = value, 1f, FadeInDuration)
			                    .SetEase(FadeInEase)
			                    .WaitForCompletion();

			// Instantiate time taking objects while displaying the logo
			var instantiationStartingTime = Time.realtimeSinceStartup;
			InstantiateObjectsAfterFadeIn();

			// Wait
			var timeToMoveOn = instantiationStartingTime + WaitDuration;
			yield return new WaitUntil(() => Time.realtimeSinceStartup > timeToMoveOn);

			// Logo fade out
			yield return DOTween.To(() => LogoPanel.alpha, value => LogoPanel.alpha = value, 0f, FadeOutDuration)
			                    .SetEase(FadeOutEase)
			                    .WaitForCompletion();

			// Load next scene
			var LevelToLoad = PlayerPrefs.GetInt("Level", 1);
			SceneManager.LoadScene(LevelToLoad);
		}

		#region Instantiate After Fade In

		[AssetsOnly]
		[ListDrawerSettings(Expanded = true)]
		public GameObject[] PrefabsToInstantiateAfterFadeIn;

		private void InstantiateObjectsAfterFadeIn()
		{
			foreach (var prefab in PrefabsToInstantiateAfterFadeIn)
			{
				Instantiate(prefab);
			}
		}

		#endregion
	}

}

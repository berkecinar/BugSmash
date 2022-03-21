using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyClap
{

	public class ProgressManager : MonoBehaviour
	{
		[NonSerialized] public int BugCount;
		public static ProgressManager instance;
		public ParticleSystem ConfettiParticle;
		public ParticleSystem SwatterParticle;
		private Swatter swatter;

		private void Awake()
		{
			instance = this;
			BugCount = FindObjectsOfType<BugAI>().Length;
			swatter = FindObjectOfType<Swatter>();
		}

		void Start()
		{
		}



		public void DecreaseBugCount()
		{
			BugCount--;
			if (BugCount < 1)
			{
				Instantiate(ConfettiParticle, PlayerController.instance.transform.position + (new Vector3(2, 4, 0)), Quaternion.identity);
				Instantiate(SwatterParticle, swatter.transform.position + (new Vector3(0, 4, 0)), Quaternion.identity);
				LevelHUD.instance.StartFeedBackText();
				PlayerController.instance.ActivateMarker();
				swatter.gameObject.SetActive(false);
				//bossBug.gameObject.SetActive(true);
			}
		}
	}

}

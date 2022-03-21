using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace EasyClap
{

	public class BossBugAI : MonoBehaviour
	{
		public NavMeshAgent BugNavMeshAgent;
		public Animator animator;

		private Swatter swatter;
		private DynamicJoystick dynamicJoystick;


		private static readonly int Die1 = Animator.StringToHash("Die");


		void Start()
		{
			swatter = GameObject.FindObjectOfType<Swatter>();
			dynamicJoystick = GameObject.FindObjectOfType<DynamicJoystick>();
			firstTime = true;
		}

		private bool speedUp;
		private bool firstTime;

		void Update()
		{
			BugNavMeshAgent.SetDestination(PlayerController.instance.transform.position);

			if (!PlayerController.instance.isDead &&
			    Vector3.Distance(transform.position, PlayerController.instance.transform.position) < 10f)
			{
				if (firstTime)
				{
					StartCoroutine(CameraController.instance.MoveToPosition(0.3f));
					LevelHUD.instance.gameObject.SetActive(false);
					dynamicJoystick.gameObject.SetActive(false);
					swatter.StopAllCoroutines();
					swatter.transform.localEulerAngles = (new Vector3(90, 0, 0));
					swatter.enabled = false;
					BugNavMeshAgent.speed = 0;
					swatter.transform.DOScale(new Vector3(1.4f, 1.4f, 1.4f), 0.2f);
					// PlayerController.instance.LastBoss = true;
					PlayerController.instance.Indicator.SetActive(true);
					firstTime = false;
					animator.SetTrigger("LastBoss");
				}
			}

			if (PlayerController.instance.isDead && !speedUp)
			{
				BugNavMeshAgent.speed *= 3f;
				animator.speed *= 3f;
				speedUp = true;
			}
		}


		private bool isDead;

		public IEnumerator ExplodeAndDestroy()
		{
			var counter = 0.2f;

			while (counter > 0f)
			{
				counter -= Time.deltaTime;
				transform.localScale += new Vector3(2.5f * Time.deltaTime, 2.5f * Time.deltaTime, 0);
				yield return new WaitForEndOfFrame();
			}

			Destroy(this.gameObject);
			ProgressManager.instance.DecreaseBugCount();
		}

		public IEnumerator ScaleUp(Transform transformToScale)
		{
			var counter = 0.4f;

			while (counter > 0f)
			{
				counter -= Time.deltaTime;
				transformToScale.localScale += new Vector3((0.4f * 0.12f), (0.4f * 0.12f), (0.4f * 0.12f));
				yield return new WaitForEndOfFrame();
			}
		}
	}

}

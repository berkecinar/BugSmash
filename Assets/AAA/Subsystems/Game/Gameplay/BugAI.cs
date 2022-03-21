using System;
using System.Collections;
using System.Collections.Generic;
using SplatterSystem;
using UnityEngine;
using UnityEngine.AI;

namespace EasyClap
{

	public class BugAI : MonoBehaviour
	{
		public NavMeshAgent BugNavMeshAgent;
		public Animator animator;

		public ParticleSystem DeathSmoke;
		public ParticleSystem RisingSmoke;
		public bool Cute;

		public float Health;
		private static readonly int Die1 = Animator.StringToHash("Die");


		void Start()
		{
			Health = Time.deltaTime * 5;
		}

		private bool speedUp;

		void Update()
		{
			if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < 50f)
			{
				BugNavMeshAgent.SetDestination(PlayerController.instance.transform.position);
			}
			else
			{
				BugNavMeshAgent.SetDestination(transform.position);
			}

			if (!PlayerController.instance.isDead && Vector3.Distance(transform.position, PlayerController.instance.transform.position) < 2f)
			{
				PlayerController.instance.Die();
			}

			if (PlayerController.instance.isDead && !speedUp)
			{
				BugNavMeshAgent.speed *= 3f;
				animator.speed *= 3f;
				speedUp = true;
			}
		}


		private bool isDead;

		public void Die()
		{
			if (!isDead)
			{
				BugNavMeshAgent.speed = 0;
				animator.SetBool(Die1, true);
				if (Cute)
				{
					StartCoroutine(ExplodeAndDestroyForCute());
				}
				else
				{
					StartCoroutine(ExplodeAndDestroy());
				}
				isDead = true;
				MeshSplatterManager.Instance.Spawn(transform.position);
				
			}
		}

		public IEnumerator ExplodeAndDestroy()
		{
			var counter = 0.1f;

			while (counter > 0f)
			{
				counter -= Time.deltaTime;
				transform.localScale += new Vector3(2.5f * Time.deltaTime, 2.5f * Time.deltaTime, 0);
				yield return new WaitForEndOfFrame();
			}

			Instantiate(DeathSmoke, transform.position, Quaternion.Euler(270, 0, 0));
			Destroy(this.gameObject);
			ProgressManager.instance.DecreaseBugCount();
		}

		public IEnumerator ExplodeAndDestroyForCute()
		{
			var counter = 0.1f;

			while (counter > 0f)
			{
				counter -= Time.deltaTime;
				transform.localScale += new Vector3(20f * Time.deltaTime, -20f * Time.deltaTime, 0);
				yield return new WaitForEndOfFrame();
			}

			Instantiate(DeathSmoke, transform.position, Quaternion.Euler(270, 0, 0));
			Destroy(this.gameObject);
			ProgressManager.instance.DecreaseBugCount();
		}
	}

}

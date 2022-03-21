using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace EasyClap
{

	public class Swatter : MonoBehaviour
	{
		private float _Time;
		public float forwardDuration = 0.2f;
		public float backwardDuration = 0.4f;


		private IEnumerator Start()
		{
			bool forward = true;


			while (true)
			{
				if (forward)
				{
					transform.DORotate(new Vector3(90, 0, 0), forwardDuration);
					yield return new WaitForSeconds(forwardDuration);
					forward = false;
				}
				else
				{
					transform.DORotate(new Vector3(180, 0, 0), backwardDuration);
					yield return new WaitForSeconds(backwardDuration);
					forward = true;
					yield return new WaitForSeconds(0.07f);
				}
			}
		}

		private void LateUpdate()
		{
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, 0);
		}


		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent<BugAI>(out BugAI bug))
			{
				bug.Die();
			}
			else if (other.gameObject.TryGetComponent<Poison>(out Poison poison))
			{
				poison.EnablePoison();
			}
		}
	}

}

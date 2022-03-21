using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyClap
{

	public class Poison : MonoBehaviour
	{
		public SphereCollider PoisonTrigger;
		public ParticleSystem PoisonParticle;



		public void EnablePoison()
		{
			PoisonTrigger.enabled = true;
			PoisonParticle.Play();
			StartCoroutine(DestroyPoisonCan());
		}


		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent<BugAI>(out BugAI bug))
			{
				bug.Die();
			}
			if (other.gameObject.TryGetComponent<Poison>(out Poison Barrel))
			{
				Barrel.PoisonTrigger.enabled = true;
				Barrel.PoisonParticle.Play();
				Barrel.StartCoroutine(Barrel.DestroyPoisonCan());
			}
		}


		public IEnumerator DestroyPoisonCan()
		{
			var counter = 0.3f;

			while (counter > 0f)
			{
				counter -= Time.deltaTime;
				//transform.localScale += new Vector3(2.5f * Time.deltaTime, 2.5f * Time.deltaTime, 0);
				yield return new WaitForEndOfFrame();
			}

			Destroy(transform.gameObject);
		}
	}

}

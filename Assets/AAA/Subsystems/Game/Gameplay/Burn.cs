using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyClap
{

	public class Burn : MonoBehaviour
	{
		private void OnTriggerStay(Collider other)
		{
			if (other.gameObject.TryGetComponent<BugAI>(out BugAI bug))
			{
				bug.Die();
			}
		}
	}

}

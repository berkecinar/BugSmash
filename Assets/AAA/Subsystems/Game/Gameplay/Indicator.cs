using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace EasyClap
{

	public class Indicator : MonoBehaviour
	{
		public Transform RotateTransform;

		public float _Angle;
		public float _Period;

		private float _Time;
		public Transform Swatter;


		private BossBugAI BossBugAi;

		// Start is called before the first frame update
		void Start()
		{
			BossBugAi = GameObject.FindObjectOfType<BossBugAI>();
		}

		private bool once;

		// Update is called once per frame
		void Update()
		{
			_Time = _Time + Time.deltaTime;

			float phase = Mathf.Sin(_Time / _Period);

			RotateTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, phase * _Angle));

			if (Input.GetMouseButtonDown(0) && !once)
			{
				Swatter.DORotate(new Vector3(180, 0, 0), 0.2f);
				StopAllCoroutines();
				StartCoroutine(BossBugAi.ExplodeAndDestroy());
				once = true;
			}
		}



		public float ShotPower(float minPower, float maxPower)
		{
			var power = 1f;

			var lerpAmount = 0f;

			if (RotateTransform.eulerAngles.z > 180)
			{
				lerpAmount = (360 - RotateTransform.eulerAngles.z) / _Angle;
			}
			else
			{
				lerpAmount = RotateTransform.eulerAngles.z / _Angle;
			}


			lerpAmount = Mathf.Abs(1 - lerpAmount);

			power = Mathf.Lerp(minPower, maxPower, lerpAmount);

			return Mathf.CeilToInt(power);
		}
	}

}

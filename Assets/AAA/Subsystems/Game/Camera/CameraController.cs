using System;
using System.Collections;
using UnityEngine;

namespace EasyClap
{

	[ExecuteAlways]
	public class CameraController : MonoBehaviour
	{
		public Transform Target;

		public Transform Head;
		public Transform CameraTransform;

		public Transform HeadRotAtBoss;
		public Transform CamPosAtBoss;

		public static CameraController instance;

		[NonSerialized] public bool ChaseTarget;

		private void Awake()
		{
			instance = this;
		}

		private void Start()
		{
			ChaseTarget = true;
		}

		void LateUpdate()
		{
			if (!ChaseTarget)
			{
				return;
			}

			transform.position = Target.position;
		}


		public IEnumerator MoveToPosition(float timeToMove)
		{
			var currentPos = CameraTransform.position;
			var currentRot = Head.rotation;
			var t = 0f;
			while (t < 1)
			{
				t += Time.deltaTime / timeToMove;
				CameraTransform.position = Vector3.Lerp(currentPos, CamPosAtBoss.position, t);
				HeadRotAtBoss.rotation = Quaternion.Lerp(currentRot, HeadRotAtBoss.rotation, t);
				yield return new WaitForEndOfFrame();
			}
		}
	}

}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EasyClap
{

	public class PlayerController : MonoBehaviour
	{
		private DynamicJoystick dynamicJoystick;
		public static PlayerController instance;
		public Animator PlayerAnimator;
		public float speed;
		public GameObject Gun;
		public GameObject Indicator;
		private EndingVehicle endingVehicle;
		public GameObject Marker;
		[NonSerialized] public bool ShowTapToPlay;
		
		private void Awake()
		{
			instance = this;
			dynamicJoystick = FindObjectOfType<DynamicJoystick>();
			endingVehicle = FindObjectOfType<EndingVehicle>();
			Marker.SetActive(false);
			MarkerActivated = false;
			ShowTapToPlay = true;
			Time.timeScale = 0f;
		}


		void Update()
		{
			if (isDead)
			{
				PlayerAnimator.speed = 1;
				return;
			}

			if (isFinished)
			{
				transform.position = endingVehicle.transform.position;
				PlayerAnimator.speed = 1;
				return;
			}

			if (ShowTapToPlay && Input.GetMouseButtonDown(0))
			{
				Time.timeScale = 1f;
				ShowTapToPlay = false;
				LevelHUD.instance.StartFadeTapToPlay();
			}


			float heading = Mathf.Atan2(dynamicJoystick.Direction.x, dynamicJoystick.Direction.y);


			if (dynamicJoystick.IsDragging)
			{
				transform.Translate(
					new Vector3(dynamicJoystick.Direction.x * speed, 0, dynamicJoystick.Direction.y * speed) * Time.deltaTime,
					Space.World);
				//PlayerAnimator.speed = 1;
				transform.rotation = Quaternion.Euler(0f, heading * Mathf.Rad2Deg, 0f);
			}
			else
			{
				PlayerAnimator.speed = 0;
			}

			if (Vector3.Distance(endingVehicle.transform.position,transform.position)<4f && !isFinished)
			{
				LevelHUD.instance.StartCoroutine(LevelHUD.instance.NextLevelAnim());
				Instantiate(ProgressManager.instance.ConfettiParticle, transform.position + (new Vector3(2, 4, 0)), Quaternion.identity);
				isFinished = true;
			}
			
		
			
		}

		private void LateUpdate()
		{
			if (MarkerActivated)
			{
				Marker.transform.position = transform.position;
				Marker.transform.LookAt(endingVehicle.transform);
				Marker.transform.localEulerAngles = new Vector3(90,Marker.transform.localEulerAngles.y,0);
			}
		}

		[NonSerialized] public bool isDead;
		[NonSerialized] public bool isFinished;
		[NonSerialized] public bool MarkerActivated;

		public void Die()
		{
			if (!isDead)
			{
				PlayerAnimator.SetBool("Die", true);
				Gun.SetActive(false);
				isDead = true;
				dynamicJoystick.gameObject.SetActive(false);
				LevelHUD.instance.ActivateRetryButton();
			}
		}

		public void BellyDance()
		{
			isFinished = true;
			PlayerAnimator.SetTrigger("Dance");
		}
		public void ActivateMarker()
		{
			Marker.transform.parent = null;
			Marker.SetActive(true);
			MarkerActivated = true;
		}
	}

}

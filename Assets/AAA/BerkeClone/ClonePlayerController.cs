using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EasyClap
{
    public class ClonePlayerController : MonoBehaviour
    {
        public static ClonePlayerController instance;
        
        public float mousePositionX=0f;
        public float mousePositionY=0f;

        public Transform endingVehicle;
        
        [SerializeField] 
        private Animator superGirlAnimation;

        [SerializeField] 
        private BerkeLevelHUD levelHud;
        
        [SerializeField] 
        private GameObject playerWeapon;

        public bool playerIsDead = false;

        private bool isGameRunning = true;
        
        public bool isReachEndingVehicle = false;
        // Start is called before the first frame update
        void Awake()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePositionX = 0f;
                mousePositionY = 0f;
            }

            float look = Mathf.Atan2(mousePositionX, mousePositionY);

            if (Input.GetMouseButton(0) && isGameRunning)
            {
                mousePositionX += Input.GetAxis("Mouse X");
                mousePositionY += Input.GetAxis("Mouse Y");

                superGirlAnimation.speed = 1;

                transform.position += new Vector3(mousePositionX/400f, 0, mousePositionY/400f);
                transform.localRotation = Quaternion.Euler(0, look * Mathf.Rad2Deg, 0);
                
            }
            else if(isGameRunning)
            {
                superGirlAnimation.speed = 0;
            }

            if (Vector3.Distance(transform.position, endingVehicle.position) < 3f)
            {
                this.gameObject.SetActive(false);
                isReachEndingVehicle = true;
                LevelComplete();
            }
            
        }

        public void LevelComplete()
        {
            playerWeapon.SetActive(false);
            superGirlAnimation.SetBool("Dance",true);
            isGameRunning = false;
            superGirlAnimation.speed = 1;
            levelHud.ShowNextLevelButton();
        }
        
        public void Die()
        {
            if (!playerIsDead)
            {
                playerWeapon.SetActive(false);
                isGameRunning = false;
                superGirlAnimation.speed = 1;
                superGirlAnimation.SetBool("Die",true);
                playerIsDead = true;
                levelHud.ShowRetryButton();
            }
        }
    }
}

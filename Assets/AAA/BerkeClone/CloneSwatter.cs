using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using DG.Tweening;
using UnityEngine;
using EZCameraShake;

namespace EasyClap
{
    public class CloneSwatter : MonoBehaviour
    {
        public float forwardDuration = 0.2f;
        public float backwardDuration = 0.4f;
        
        // Update is called once per frame
        void Update()
        {


        }
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
            if (other.gameObject.TryGetComponent<BerkeSpiderEnemy>(out BerkeSpiderEnemy spider))
            {
                BerkeCameraFollow.instance.enabled=false;
                CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
                
                spider.EnemyDie();
            }
            else if (other.gameObject.TryGetComponent<BerkeBarrelController>(out BerkeBarrelController barrel))
            {
                CameraShaker.Instance.ShakeOnce(6f, 6f, 0.1f, 1f);
                barrel.Explosion();
            }
        }

        /*
         private IEnumerator MoveUpAndDown()
        {
            if (forward)
            {
                while (transform.rotation.x < 180)
                {
                    transform.Rotate(Vector3.right);
                }
                yield return new WaitForSeconds(0.5f);
                forward = false;
            }
            else
            {
                while (transform.rotation.x >= 90)
                {
                    transform.Rotate(Vector3.left);
                }
                yield return new WaitForSeconds(0.5f);
                forward = true;
                yield return new WaitForSeconds(0.07f);
            }
        }
         */

    }
}

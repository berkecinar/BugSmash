using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyClap
{
    [ExecuteAlways]
    public class BerkeCameraFollow : MonoBehaviour
    {
        public static BerkeCameraFollow instance;
        
        public Transform targetTransform;

        public Vector3 offSet;

        [SerializeField] 
        private float smoothSpeed = 0.125f;


        private void Awake()
        {
            instance=this;
        }

        private void Update()
        {
            Vector3 desiredPosition = targetTransform.position + offSet;
            Vector3 smoothedPosition = Vector3.Lerp(targetTransform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
            transform.LookAt(targetTransform);
        }
    }
}

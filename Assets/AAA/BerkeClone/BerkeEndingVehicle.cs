using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyClap
{
    public class BerkeEndingVehicle : MonoBehaviour
    {
        [SerializeField] 
        private float highesPoint;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (ClonePlayerController.instance.isReachEndingVehicle)
            {
                BerkeCameraFollow.instance.targetTransform = this.transform;
                transform.Translate(transform.forward * (Time.deltaTime * 30),Space.Self);
            }
        }
        
    }
}

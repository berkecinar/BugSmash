using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyClap
{
    public class EndingVehicle : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (PlayerController.instance.isFinished.Equals(true))
            {
                transform.Translate(transform.forward * (Time.deltaTime * 30),Space.Self);
            }
        }
        
        
        
    }
}
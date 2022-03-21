using System;
using System.Collections;
using System.Collections.Generic;
using SplatterSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EasyClap
{
    public class BerkeBodyPart : MonoBehaviour
    {
        public Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {
            int xSign = Random.Range(0, 2);
            int zSign = Random.Range(0, 2);
            
            float x = Random.Range(3f, 4f);
            if (xSign == 0)
            {
                x *= -1f;
            }
            
            float z = Random.Range(2.5f, 3f);
            if (zSign == 0)
            {
                z *= -1f;
            }

            float y = Random.Range(0.6f, 1f);
            
            
            rb.AddForce(x,y,z,ForceMode.Impulse);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnCollisionEnter(Collision other)
        {
            if (CompareTag("Ground"))
            {
                MeshSplatterManager.Instance.Spawn(transform.position);
            }
        }
    }
}

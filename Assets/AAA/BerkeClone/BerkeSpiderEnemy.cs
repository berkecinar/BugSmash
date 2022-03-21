using System;
using System.Collections;
using System.Collections.Generic;
using Extenity.ReflectionToolbox;
using SplatterSystem;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;


namespace EasyClap
{

    public class BerkeSpiderEnemy : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent spiderEnemyNavMash;

        [SerializeField] 
        private Animator spiderEnemyAnimator;

        [SerializeField] 
        private BerkeLevelHUD levelHUD;

        [SerializeField]
        private GameObject bodyPart;


        private bool isDead = false;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            spiderEnemyNavMash.SetDestination(ClonePlayerController.instance.transform.position);

            if (Vector3.Distance(transform.position, ClonePlayerController.instance.transform.position) < 2f && !ClonePlayerController.instance.playerIsDead && !isDead)
            {
                ClonePlayerController.instance.Die();
                spiderEnemyNavMash.speed = 0;
            }
        }

        public void EnemyDie()
        {
            if (!isDead)
            {
                spiderEnemyNavMash.speed = 0;
                Destroy(spiderEnemyAnimator);
                transform.localScale = new Vector3(transform.localScale.x, 0f, transform.localScale.z);
                transform.position += Vector3.up;
                
                //spiderEnemyAnimator.SetBool("Die", true);
                isDead = true;
                Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                MeshSplatterManager.Instance.Spawn(transform.position);

                
                for (int i = 0;  i <= 20; i++)
                {
                    Instantiate(bodyPart, spawnPoint, Quaternion.identity);
                }
                //Destroy(this.gameObject,0.5f);
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyClap
{
    public class BerkeBarrelController : MonoBehaviour
    {
        [SerializeField]
        private SphereCollider barrelEffectRangeCollider;

        [SerializeField] 
        private ParticleSystem barrelExplosionParticle;

        [SerializeField] 
        private GameObject barrelMesh;

        private bool isExploded = false;
        public void Explosion()
        {
            if (!isExploded)
            {
                barrelEffectRangeCollider.enabled = true;
                barrelExplosionParticle.Play();
                barrelMesh.SetActive(false);
                Destroy(this.gameObject,.6f);
            }
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<BerkeSpiderEnemy>(out BerkeSpiderEnemy spider))
            {
                spider.EnemyDie();
            }
            else if (other.gameObject.TryGetComponent<BerkeBarrelController>(out BerkeBarrelController barrel))
            {
                barrel.StartCoroutine(ExplodeBarrel());
            }
        }

       IEnumerator ExplodeBarrel()
        {
            yield return new WaitForSeconds(0.5f);
            Explosion();
        }

    }
}

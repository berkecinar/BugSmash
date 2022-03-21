using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SplatterSystem.TopDown {
		
	public class Target : MonoBehaviour {
		public MeshSplatterManager splatter;
		
		public SplatterSettings dieSplatterSettins;
		public Color dieSplatterColor = Color.red;
		

		private static int numTargets = 0;
		private float shakeMagnitude;
		private float shakeDuration;
		private bool isDead = false;

		void Start() {
            if (splatter == null) {
                Debug.LogError("[SPLATTER SYSTEM] No splatter manager attached to target.");
                return;
            }
            

			if (numTargets == 0) {
				numTargets = FindObjectsOfType<Target>().Length;
			}
			
		}
		
		public void HandleDeath() {
			if (isDead) return;
			isDead = true;

			splatter.Spawn(dieSplatterSettins, transform.position, null, dieSplatterColor);

			
				gameObject.SetActive(false);
			
		}
		
	}

}
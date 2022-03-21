using UnityEditor;
using UnityEngine;

namespace EasyClap
{

	public static class Configuration
	{
		private static ConfigurationData _Current;
		public static ConfigurationData Current
		{
			get
			{
				if (_Current == null)
				{
#if UNITY_EDITOR
					if (!Application.isPlaying)
					{
						Debug.Log("Getting configuration from GameApplication");
						var go = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/AAA/Subsystems/Application/GameApplication.prefab");
						var gameApplication = go.GetComponent<GameApplication>();
						_Current = gameApplication.ConfigurationData;
					}
#endif
				}
				return _Current;
			}
		}

		public static void SetCurrent(ConfigurationData configuration)
		{
			_Current = configuration;
		}
	}

}

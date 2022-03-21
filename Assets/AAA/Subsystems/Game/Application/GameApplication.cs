using Extenity.MessagingToolbox;
using Sirenix.OdinInspector;
using UnityEngine;

namespace EasyClap
{

	public class GameApplication : MonoBehaviour
	{
		void Awake()
		{
			Messenger.IsEmitLoggingEnabled = Constants.EnableMessengerEmitLogging;
			Messenger.IsRegistrationLoggingEnabled = Constants.EnableMessengerRegistrationLogging;
			Messenger.EmitLogFilter = Constants.MessengerEmitLogFilter;

			Application.targetFrameRate = 60;
			QualitySettings.vSyncCount = 0;

			ApplyConfiguration();
		}

		#region Configuration

		[AssetList(Path = "AAA/Content/Configuration", AutoPopulate = true)]
		[OnValueChanged(nameof(ApplyConfiguration))]
		[InlineEditor(Expanded = true)]
		public ConfigurationData ConfigurationData;

		private void ApplyConfiguration()
		{
			Configuration.SetCurrent(ConfigurationData);
		}

		#endregion
	}

}

using Extenity.MessagingToolbox;
using UnityEngine;

namespace EasyClap
{

	public class Messages : BaseMessages
	{
		// Gameplay
		public const string MenuStarted = "MenuStarted";
		public const string LevelStarted = "LevelStarted";
		public const string LevelCompleted = "LevelCompleted";
		public const string LevelFailed = "LevelFailed";
		public const string Clicked_NoThanksButtonOnLevelFailed = "Clicked_NoThanksButtonOnLevelFailed";

		// Content
		public const string NewContentUnlocked = "NewContentUnlocked";

		// Screens
		public const string RequestShowShopScreen = "RequestShowShopScreen";
		public const string RequestHideShopScreen = "RequestHideShopScreen";
		public const string RequestShowSettingsScreen = "RequestShowSettingsScreen";
		public const string RequestHideSettingsScreen = "RequestHideSettingsScreen";

		// Settings
		public const string SwitchSoundsOn = "SwitchSoundsOn";
		public const string SwitchSoundsOff = "SwitchSoundsOff";
		public const string SwitchHapticOn = "SwitchHapticOn";
		public const string SwitchHapticOff = "SwitchHapticOff";

		// Cheats
		public const string Cheat_RequestShowCheatScreen = "Cheat_RequestShowCheatScreen";
		public const string Cheat_RequestHideCheatScreen = "Cheat_RequestHideCheatScreen";
		public const string Cheat_DisableCurrencyUI = "Cheat_DisableCurrencyUI";
		public const string Cheat_EnableCurrencyUI = "Cheat_EnableCurrencyUI";
		public const string Cheat_HideEnvironment = "Cheat_HideEnvironment";
		public const string Cheat_ShowEnvironment = "Cheat_ShowEnvironment";

		// Ads
		// public const string AdFinish_GetKeys = "AdFinish_GetKeys";
		// public const string AdFinish_ContinueLevel = "AdFinish_ContinueLevel";
		// public const string AdFinish_Claim5XCoins = "AdFinish_Claim5XCoins";
		// public const string AdFinish_LevelFailedInterstitial = "AdFinish_Interstitial";
		// public const string AdFinish_RefuseClaim5XCoinsInterstitial = "AdFinish_RefuseClaim5XCoinsInterstitial";
		// public const string AdFinish_GetMoreCoins = "AdFinish_GetMoreCoins";
		//
		// public const string AdSkippedOrFailed_ContinueLevel = "AdSkippedOrFailed_ContinueLevel";
		// public const string AdSkippedOrFailed_GetKeys = "AdSkippedOrFailed_GetKeys";
		// public const string AdSkippedOrFailed_Claim5XCoins = "AdSkippedOrFailed_Claim5XCoins";
		// public const string AdSkippedOrFailed_GetMoreCoins = "AdSkippedOrFailed_GetMoreCoins";

		#region Register To Messenger

#if UNITY_EDITOR
		[UnityEditor.InitializeOnLoadMethod]
#endif
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void RegisterToMessenger()
		{
			Messenger.AddConstStringFieldsAsEventNames(typeof(Messages));
		}

		#endregion
	}

}

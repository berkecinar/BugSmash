#if UNITY_EDITOR
#define EnableCheats // TODO: Find another easier way to always include cheats in Editor.
#endif

using Extenity.MessagingToolbox;
using Extenity.UIToolbox.ScreenManagement;
using Screen = Extenity.UIToolbox.ScreenManagement.Screen;

namespace EasyClap
{

	public class Screens : ScreensBase
	{
		#region Initialization

		protected override void RegisterEvents()
		{
			InitializeMenuScreen();
			InitializeIngameScreen();
			InitializeSettingsScreen();
			InitializeOfflineGainScreen();
			InitializeCheatScreen();

			Messenger.RegisterEvent(Messages.MenuStarted, () =>
			{
				// if (!GameManager.Instance.Data.IsTutorialCompleted)
				// {
				// 	// Continue to tutorial.
				// 	SwitchToIngameScreen();
				// 	return;
				// }

				SwitchToMenuScreen();
			});

			Messenger.RegisterEvent(Messages.LevelStarted, () =>
			{
				// if (!GameManager.Instance.Data.IsTutorialCompleted)
				// {
				// 	// Continue to tutorial.
				// 	SwitchToIngameScreen();
				// 	return;
				// }

				SwitchToOfflineGainScreen();
			});
		}

		#endregion

		#region Display - Currency

		public Screen CurrencyDisplay;
		private bool ForceDisableCurrencyDisplay;

		private void ActivateForceDisablingCurrencyDisplay()
		{
			ForceDisableCurrencyDisplay = true;
			SwitchToIngameScreen(); // Refresh UI
		}

		private void DeactivateForceDisablingCurrencyDisplay()
		{
			ForceDisableCurrencyDisplay = false;
			SwitchToIngameScreen(); // Refresh UI
		}

		private void ShowCurrencyDisplay()
		{
			if (ForceDisableCurrencyDisplay)
			{
				HideCurrencyDisplay();
				return;
			}
			ShowOrCreateScreen(CurrencyDisplay);
		}

		private void HideCurrencyDisplay()
		{
			HideScreen(CurrencyDisplay);
		}

		#endregion

		#region Screen - Menu

		private void InitializeMenuScreen()
		{
		}

		private void SwitchToMenuScreen()
		{
			HideCurrencyDisplay();
		}

		#endregion

		#region Screen - Ingame

		private void InitializeIngameScreen()
		{
		}

		private void SwitchToIngameScreen()
		{
			ShowCurrencyDisplay();
		}

		#endregion

		#region Screen - Offline Gain

		// public Screen OfflineGainScreen;

		private void InitializeOfflineGainScreen()
		{
			// Messenger.RegisterEvent(Messages.OnApplicationResumed, () =>
			// {
			// 	if (GameManager.Instance.Data.IsTutorialCompleted) // Do not show offline gain screen if the player is still in tutorial.
			// 	{
			// 		SwitchToOfflineGainScreen();
			// 	}
			// });
			//
			// Messenger.RegisterEvent(Messages.RequestCloseOfflineGainScreenWithBonus, () =>
			// {
			// 	HideScreen(OfflineGainScreen);
			// 	SwitchToIngameScreen();
			// });
			// Messenger.RegisterEvent(Messages.RequestCloseOfflineGainScreenWithoutBonus, () =>
			// {
			// 	HideScreen(OfflineGainScreen);
			// 	SwitchToIngameScreen();
			// });
		}

		private void SwitchToOfflineGainScreen()
		{
			// HideScreen(...);
			// ShowCurrencyDisplay();
			// ShowOrCreateScreen(OfflineGainScreen);
		}

		#endregion

		#region Screen - Settings

		public Screen SettingsScreen;

		private void InitializeSettingsScreen()
		{
			Messenger.RegisterEvent(Messages.RequestShowSettingsScreen, () =>
			{
				ShowOrCreateScreen(SettingsScreen);
			});
			Messenger.RegisterEvent(Messages.RequestHideSettingsScreen, () =>
			{
				HideScreen(SettingsScreen);
			});
		}

		#endregion

		#region Screen - Cheat

#if EnableCheats

		public Screen CheatScreen;
		public Screen CheatLauncherScreen;

		private void InitializeCheatScreen()
		{
			ShowOrCreateScreen(CheatLauncherScreen); // Always display launcher screen in cheat enabled builds.

			Messenger.RegisterEvent(Messages.Cheat_RequestShowCheatScreen, ShowCheatScreen);
			Messenger.RegisterEvent(Messages.Cheat_RequestHideCheatScreen, HideCheatScreen);
			Messenger.RegisterEvent(Messages.Cheat_DisableCurrencyUI, ActivateForceDisablingCurrencyDisplay);
			Messenger.RegisterEvent(Messages.Cheat_EnableCurrencyUI, DeactivateForceDisablingCurrencyDisplay);
		}

		private void ShowCheatScreen()
		{
			ShowOrCreateScreen(CheatScreen);
		}

		private void HideCheatScreen()
		{
			HideScreen(CheatScreen);
		}

#else

		[System.Diagnostics.Conditional("EnableCheats")]
		private void InitializeCheatScreen()
		{
			// Dummy
		}

#endif

		#endregion
	}

}

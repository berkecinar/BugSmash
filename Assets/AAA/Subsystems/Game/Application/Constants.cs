using System.Collections.Generic;

namespace EasyClap
{

	public static class Constants
	{
		#region Ads

		public const float NoThanksButtonDisplayDelay = 3.5f;

		#endregion

		#region Ad Placements

		/*
		/// <summary>
		/// Rewarded video to multiply gained coins after a successful run.
		/// </summary>
		public const string MultiplyCoinsAfterSucceeded = "MultiplyCoinsAfterSucceeded"; // Reward: 1 MultipliedCoins
		/// <summary>
		/// Interstitial video that is played from time to time after a successful run.
		/// </summary>
		public const string RefuseRewardAfterSucceeded = "RefuseRewardAfterSucceeded";

		/// <summary>
		/// Rewarded video to revive after a failed run.
		/// </summary>
		public const string ReviveAfterFailed = "ReviveAfterFailed"; // Reward: 1 Revive
		/// <summary>
		/// Interstitial video after a failed run.
		/// </summary>
		public const string RefuseReviveAfterFailed = "RefuseReviveAfterFailed";

		/// <summary>
		/// Rewarded video to get more keys that unlocks items.
		/// </summary>
		public const string GainKeys = "GainKeys"; // Reward: 1 KeyBag
		/// <summary>
		/// Rewarded video to get some coins. Placed in inventory screen.
		/// </summary>
		public const string GainCoins = "GainCoins"; // Reward: 1 CoinBag

		public static readonly string[] AdPlacementIDs = new string[]
		{
			MultiplyCoinsAfterSucceeded,
			RefuseRewardAfterSucceeded,
			ReviveAfterFailed,
			RefuseReviveAfterFailed,
			GainKeys,
			GainCoins,
		};
		*/

		#endregion

		#region SDK

		// #if UNITY_IOS
		// public const string UnityAdsGameID = "...
		// #elif UNITY_ANDROID
		// public const string UnityAdsGameID = "...
		// #else
		// public const string UnityAdsGameID = "";
		// #endif

		// public const string IronSourceAppID = "...
		// public const string AdMobAppID = "ca-app-pub-...

		#endregion

		#region Scenes

		public const string SplashScene = "Splash";
		public const string GameScene = "Game";

		#endregion

		#region Scores

		// public const int ScorePerCollect = 42;

		#endregion

		#region Messenger

		public const bool EnableMessengerRegistrationLogging = false;
		public const bool EnableMessengerEmitLogging = true;
		public static readonly HashSet<string> MessengerEmitLogFilter = new HashSet<string>()
		{
			// "HitObject",
			// "RefreshScore",
		};

		#endregion
	}

}

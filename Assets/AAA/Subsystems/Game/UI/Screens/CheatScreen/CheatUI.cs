#if UNITY_EDITOR
#define EnableCheats // TODO: Find another easier way to always include cheats in Editor.
#endif

#if EnableCheats

using System;
using Extenity.MessagingToolbox;
using Extenity.UIToolbox;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace EasyClap
{

	public class CheatUI : PanelMonoBehaviour
	{
		protected void Start()
		{
			InitializeCurrency();
			InitializeUserData();
			InitializeHideEnvironment();
		}

		#region User Data

		[Title("User Data")]
		[FormerlySerializedAs("ResetAllButton")]
		[Required]
		public Button ResetUserDataButton;

		private void InitializeUserData()
		{
			ResetUserDataButton.onClick.AddListener(ResetUserData);
		}

		private void ResetUserData()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Currency

		[Title("Currency")]
		[Required]
		public TMP_InputField AddCustomCurrencyAmountField;
		[Required]
		public Button AddCustomCurrencyAmountButton;
		[Required]
		public Button AddCurrencyButton_1K;
		[Required]
		public Button AddCurrencyButton_1M;
		[Required]
		public Button AddCurrencyButton_1B;
		[Required]
		public Button AddCurrencyButton_1T;

		private void InitializeCurrency()
		{
			AddCustomCurrencyAmountButton.onClick.AddListener(OnAddCustomCurrencyAmountButtonClicked);
			AddCurrencyButton_1K.onClick.AddListener(AddCurrency_1K);
			AddCurrencyButton_1M.onClick.AddListener(AddCurrency_1M);
			AddCurrencyButton_1B.onClick.AddListener(AddCurrency_1B);
			AddCurrencyButton_1T.onClick.AddListener(AddCurrency_1T);
		}

		private void AddCurrency(double amount)
		{
			throw new NotImplementedException("Not implemented yet! CheatUI should call currency related manager here.");
		}

		private void AddCurrency_1K()
		{
			AddCurrency(1e3);
		}

		private void AddCurrency_1M()
		{
			AddCurrency(1e6);
		}

		private void AddCurrency_1B()
		{
			AddCurrency(1e9);
		}

		private void AddCurrency_1T()
		{
			AddCurrency(1e12);
		}

		private void OnAddCustomCurrencyAmountButtonClicked()
		{
			if (double.TryParse(AddCustomCurrencyAmountField.text, out var currency))
			{
				AddCurrency(currency);
			}
		}

		#endregion

		#region Hide Environment

		[Required]
		public Toggle HideEnvironmentToggle;

		private void InitializeHideEnvironment()
		{
			HideEnvironmentToggle.onValueChanged.AddListener(OnHideEnvironmentToggleChanged);
		}

		private void OnHideEnvironmentToggleChanged(bool value)
		{
			if (value)
				Messenger.EmitEvent(Messages.Cheat_HideEnvironment);
			else
				Messenger.EmitEvent(Messages.Cheat_ShowEnvironment);
		}

		#endregion
	}

}

#endif

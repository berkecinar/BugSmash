using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace EasyClap
{

	public class CurrencyUI : MonoBehaviour
	{
		[Required]
		public TextMeshProUGUI CurrencyText;
		[Required]
		public TextMeshProUGUI TotalIncomeText;

		protected void Update()
		{
			var amount = 0f;
			var totalIncomeRate = 0f;
			CurrencyText.text = amount.ToString("N0");
			TotalIncomeText.text = $"{totalIncomeRate:N0}/s";
		}
	}

}

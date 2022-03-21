using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace EasyClap
{

	public static class DevelopmentMenu
	{
		private const string Menu = "DEVELOPMENT/";

		[MenuItem(Menu + "Example Process", priority = 10000)]
		public static void ExampleProcess()
		{
			Debug.Log("Doing some development related operations here...");
		}

		[MenuItem(Menu + "Example Process (Async)", priority = 10002)]
		public static async void ExampleProcessAsync()
		{
			Debug.Log("Doing some async development related operations here...");
			await Task.Run(() =>
			{
				Debug.Log("   Processing...");
				Thread.Sleep(1000);
				Debug.Log("   Processed.");
			});
			Debug.Log("Done.");
		}
	}

}

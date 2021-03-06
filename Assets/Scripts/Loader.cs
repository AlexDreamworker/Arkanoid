using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
	public class Loader
	{
		private const string Main = "Main";
		private const string Game = "Game";

		public void LoadingMainScene(bool value)
		{
			SceneManager.LoadSceneAsync(value ? Main : Game);
		}
	}
}


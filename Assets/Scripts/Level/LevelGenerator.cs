using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Arkanoid
{
	public class LevelGenerator : MonoBehaviour
	{
		private readonly LevelIndex _levelIndex = new LevelIndex();
		private readonly BlockGenerator _blockGenerator = new BlockGenerator();
		[SerializeField] private Transform _parentBlocks;
		[SerializeField] private ClearLevel _clearLevel;
		[SerializeField] private GameState _gameState;
		[SerializeField] private UnityEvent OnGenerated;

		private void Start()
		{
			Init();
		}

		private void Init() 
		{
			_clearLevel.Clear();
			GameLevel gameLevel = Resources.Load<GameLevel>($"Levels/Level{_levelIndex.GetIndex()}");
			if (gameLevel != null) 
			{
				_blockGenerator.Generate(gameLevel, _parentBlocks);
			}			
			LoadingScreen.Screen.Enable(false);
			OnGenerated.Invoke();
			_gameState.SetState(State.Gameplay);
		}

		public void Generate() 
		{
			LoadingScreen.Screen.Enable(true);
			Init();
		}
	}
}


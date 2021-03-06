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
		[Space]
		[SerializeField] private SpriteRenderer _background;

		private void Start()
		{
			_gameState.SetState(State.StopGame);
			Init();
		}

		private void Init() 
		{
			_clearLevel.Clear();
			GameLevel gameLevel = Resources.Load<GameLevel>($"Levels/Level{_levelIndex.GetIndex()}");
			if (gameLevel != null) 
			{
				_blockGenerator.Generate(gameLevel, _parentBlocks);
				_background.sprite = gameLevel.Background;
			}			
			LoadingScreen.Screen.Enable(false);
			_gameState.SetState(State.Gameplay);
			OnGenerated.Invoke();
		}

		public void Generate() 
		{
			LoadingScreen.Screen.Enable(true);
			Init();
		}

		public void GenerateNext() 
		{
			LevelsData levelsData = new LevelsData();
			int tempIndex = _levelIndex.GetIndex();
			if (tempIndex < levelsData.GetLevelsProgress().Levels.Count - 1) 
			{
				_levelIndex.SetIndex(tempIndex + 1);
				Generate();
			}
			else
			{
				Loader loader = new Loader();
				_gameState.SetState(State.Other);
				loader.LoadingMainScene(true);
			}
		}
	}
}


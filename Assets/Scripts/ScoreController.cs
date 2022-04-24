using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	public class ScoreController : MonoBehaviour
	{
		[SerializeField] private GameState _gameState;
		private int _score;
		[SerializeField] private UnityEventInt UiUpdate;

		public int GetScore()
		{
			return _score;
		}

		public void SetDefault()
		{
			_score = 0;
			UiUpdate.Invoke(_score);
		}

		private void OnEnable()
		{
			Block.OnDestroyed += ScoreCollect;
			Bonus.OnAdded += ScoreCollect;
		}

		private void OnDisable()
		{
			Block.OnDestroyed -= ScoreCollect;
			Bonus.OnAdded -= ScoreCollect;
		}

		private void ScoreCollect(int value)
		{
			if (_gameState.State == State.Gameplay) 
			{
				_score += value;
				UiUpdate.Invoke(_score);
			}
		}
	}
}


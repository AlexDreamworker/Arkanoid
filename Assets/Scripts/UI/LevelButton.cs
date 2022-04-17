using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
	public class LevelButton : MonoBehaviour
	{
		[SerializeField] private Button _button;
		[SerializeField] private Text _buttonText;
		[SerializeField] private Image _starsImage;
		[SerializeField] private Sprite[] _starsSprites;
		private int _index;

		public void SetData(Progress progress, int index) 
		{
			_buttonText.text = index.ToString();
			_index = index;
			_button.interactable = progress.IsOpened;
			_starsImage.sprite = _starsSprites[progress.StarsCount];
		}
	}
}


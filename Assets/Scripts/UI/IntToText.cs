using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
	public class IntToText : MonoBehaviour
	{
		[SerializeField] private Text _text;

		public void SetInt(int value)
		{
			_text.text = value.ToString();
		}
	}
}


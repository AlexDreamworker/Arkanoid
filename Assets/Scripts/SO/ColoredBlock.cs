using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	[CreateAssetMenu(fileName = "ColoredBlock", menuName = "GameData/Create/ColoredBlock")]
	public class ColoredBlock : BlockData
	{
		public List<Sprite> Sprites;
		public Color BaseColor;
		public int Score;
	}
}


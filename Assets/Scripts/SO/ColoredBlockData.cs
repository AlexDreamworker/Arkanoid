using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	[CreateAssetMenu(fileName = "ColoredBlockData", menuName = "GameData/Create/ColoredBlockData")]
	public class ColoredBlockData : BlockData
	{
		public List<Sprite> Sprites;
		public Color BaseColor;
		public int Score;
	}
}


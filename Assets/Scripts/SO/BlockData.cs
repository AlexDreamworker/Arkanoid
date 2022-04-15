using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	[CreateAssetMenu(fileName = "BlockData", menuName = "GameData/Create/BlockData")]
	public class BlockData : ScriptableObject
	{
		public GameObject Prefab;
		public List<Sprite> Sprites;
		public Color BaseColor;
		public int Score;
	}
}


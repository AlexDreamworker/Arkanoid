using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	[CreateAssetMenu(fileName = "BlockData", menuName = "GameData/Create/BlockData")]
	public class BlockData : ScriptableObject
	{
		public GameObject Prefab;
	}
}


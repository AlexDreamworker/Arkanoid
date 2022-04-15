using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	public class BlockGenerator : MonoBehaviour
	{
		[SerializeField] private List<BlockData> _blocks;

		private void Start()
		{
			for (var i = 0; i < _blocks.Count; i++)
			{
				GameObject game = Instantiate(_blocks[i].Prefab, new Vector3(0 + i, 0, 0), Quaternion.identity);

				if (game.TryGetComponent(out Block block)) 
				{
					block.SetData(_blocks[i]);
				}
			}
		}
	}
}


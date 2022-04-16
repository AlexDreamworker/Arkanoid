#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
namespace Arkanoid
{
	public class BlockGenerator
	{
		public void Generate(GameLevel gameLevel, Transform parent) 
		{
			for (var i = 0; i < gameLevel.Blocks.Count; i++)
			{
				GameObject game;
#if UNITY_EDITOR
				game = PrefabUtility.InstantiatePrefab(gameLevel.Blocks[i].Block.Prefab, parent) as GameObject;
				if (game.TryGetComponent(out Block block)) 
				{
					block.BlockData = gameLevel.Blocks[i].Block;
					block.SetData(gameLevel.Blocks[i].Block as ColoredBlock);
				}
				
				if (game.TryGetComponent(out OtherBlock other)) 
				{
					other.BlockData = gameLevel.Blocks[i].Block;
				}
#else
				game = GameObject.Instantiate(gameLevel.Blocks[i].Block.Prefab, parent);
				if (game.TryGetComponent(out Block block)) 
				{
					ColoredBlock coloredBlock = gameLevel.Blocks[i].Block as ColoredBlock;
					block.SetData(coloredBlock);
				}
#endif
				game.transform.position = gameLevel.Blocks[i].Position;
			}
		}
	}
}


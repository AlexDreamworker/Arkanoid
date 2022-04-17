using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	public class ClearLevel : MonoBehaviour
	{
		public void Clear() 
		{
			BaseBlock[] allBlocks = FindObjectsOfType<BaseBlock>();
			if (allBlocks.Length > 0) 
			{
				foreach (var item in allBlocks)
				{
#if UNITY_EDITOR
					DestroyImmediate(item.gameObject);
#else
					Destroy(item.gameObject);
#endif
				}
			}
		}
	}
}


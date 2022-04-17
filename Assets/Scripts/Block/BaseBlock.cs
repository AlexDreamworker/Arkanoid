using UnityEngine;

namespace Arkanoid
{
	public abstract class BaseBlock : MonoBehaviour
	{
#if UNITY_EDITOR
		public BlockData BlockData;
#endif
	}
}


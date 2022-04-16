using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{	
	[CreateAssetMenu(fileName = "EditorData", menuName = "EditorData/Create/Data")]
	public class EditorData : ScriptableObject
	{
		public List<EditorBlock> BlockDatas = new List<EditorBlock>();
	}

	[System.Serializable]
	public class EditorBlock 
	{
		public Texture2D Texture2D;
		public BlockData BlockData;
	}
}


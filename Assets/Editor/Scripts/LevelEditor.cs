using System.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Arkanoid
{	
	public class LevelEditor : EditorWindow
	{
		private Transform _parent;
		private EditorData _data;
		private int _index;

		[MenuItem("Window/Level Editor")]
		public static void Init() 
		{
			LevelEditor levelEditor = GetWindow<LevelEditor>("Level Editor");
			levelEditor.Show();
		}

		private void OnGUI() 
		{
			EditorGUILayout.Space(10); // отступ
			_parent = (Transform)EditorGUILayout.ObjectField(_parent, typeof(Transform), true); // true - выбрать из ассетов или сцены
			EditorGUILayout.Space(30); // отступ

			if (_data == null) 
			{
				if (GUILayout.Button("Load data")) 
				{
					_data = (EditorData)AssetDatabase.LoadAssetAtPath("Assets/Editor/Data/EditorData.asset", typeof(EditorData));
				}
			}
			else 
			{
				GUILayout.BeginHorizontal(); // горизонтальная группа - начало
				GUILayout.FlexibleSpace(); // пустое пространство
				GUILayout.Label("Block Prefab", EditorStyles.boldLabel);
				GUILayout.FlexibleSpace(); // пустое пространство
				GUILayout.EndHorizontal(); // горизонтальная группа - конец

				GUILayout.Space(5);
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				if (GUILayout.Button("<", GUILayout.Width(50), GUILayout.Height(50))) 
				{
					_index--;
					if (_index < 0) 
					{
						_index = _data.BlockDatas.Count - 1;
					}
				}

				//* Получение цвета блока
				if (_data.BlockDatas[_index].BlockData is ColoredBlockData) 
				{
					ColoredBlockData coloredBlockData = _data.BlockDatas[_index].BlockData as ColoredBlockData;
					GUI.color = coloredBlockData.BaseColor;
				}
				else 
				{
					GUI.color = Color.white;
				}

				GUILayout.Label(_data.BlockDatas[_index].Texture2D);
				GUI.color = Color.white;

				if (GUILayout.Button(">", GUILayout.Width(50), GUILayout.Height(50))) 
				{
					_index++;
					if (_index > _data.BlockDatas.Count - 1) 
					{
						_index = 0;
					}
				}

				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
			}
		}
	}
}


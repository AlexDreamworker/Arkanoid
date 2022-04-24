using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	public class BonusMove : MonoBehaviour
	{
		private const float Speed = 5f;

		private void Update()
		{
			transform.Translate(Vector3.down * Speed * Time.deltaTime);
		}
	}
}


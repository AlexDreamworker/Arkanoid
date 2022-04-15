using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	public class BallMove : MonoBehaviour
	{
		private Rigidbody2D _rigidbody2D;
		private bool _isActive;
		private const float Force = 500f;
		private const float OffsetX = 100f;

		private void Start()
		{
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
		}

		private void Update()
		{
#if UNITY_EDITOR
			if (Input.GetKeyDown(KeyCode.Backspace) && !_isActive) 
			{
				BallActivate();
			}
#endif
#if UNITY_ANDROID
			if (Input.touchCount > 0 && !_isActive)  
			{
				Touch touch = Input.GetTouch(0);
				if (touch.tapCount > 1) 
				{
					BallActivate();
				}
			}
#endif
		}

		private void BallActivate() 
		{
			_isActive = true;
			transform.SetParent(null);
			_rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
			_rigidbody2D.AddForce(new Vector2(OffsetX, Force));
		}
	}
}


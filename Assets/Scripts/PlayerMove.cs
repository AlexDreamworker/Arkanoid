using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dreamworker
{
	public class PlayerMove : MonoBehaviour
	{
		private Rigidbody2D _rigidbody2D;

		private float _moveX = 0f;
		private float _speed = 15f;

		private void Awake()
		{
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}
		
		private void FixedUpdate()
		{
			float positionX = _rigidbody2D.position.x + _moveX * _speed * Time.fixedDeltaTime;

			_rigidbody2D.MovePosition(new Vector2(positionX, _rigidbody2D.position.y));
		}

		private void OnEnable()
		{
			PlayerInput.OnMove += Move;
		}

		private void OnDisable()
		{
			PlayerInput.OnMove -= Move;
		}

		private void Move(float moveX) 
		{
			_moveX = moveX;
		}
	}
}


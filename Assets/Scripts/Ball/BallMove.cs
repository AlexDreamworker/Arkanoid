using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	public class BallMove : MonoBehaviour
	{
		private Rigidbody2D _rigidbody2D;
		private bool _isActive;
		private const float Force = 300f;
		[SerializeField] private BallSound _ballSound;

		private void Start()
		{
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
		}

		private void OnEnable()
		{
			PlayerInput.OnClicked += BallActivate;
		}

		private void OnDisable()
		{
			PlayerInput.OnClicked -= BallActivate;
		}

		private void BallActivate() 
		{
			if (!_isActive)
			{
				_isActive = true;
				transform.SetParent(null);
				_rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
				AddForce();
				_ballSound.PlaySoundAwake();
			}
		}

		public void AddForce(float direction = 0f) 
		{
			_rigidbody2D.velocity = Vector2.zero;
			_rigidbody2D.AddForce(new Vector2(direction * (Force / 2), Force));
		}
	}
}


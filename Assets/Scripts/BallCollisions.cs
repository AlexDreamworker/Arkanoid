using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	public class BallCollisions : MonoBehaviour
	{
		[SerializeField] private BallMove _ball;
		private float _lastPositionX;

		private void OnCollisionEnter2D(Collision2D collision)
		{
			float ballPositionX = transform.position.x;

			if (collision.gameObject.TryGetComponent(out PlayerMove playerMove))
			{
				if (ballPositionX < _lastPositionX + 0.1f && ballPositionX > _lastPositionX - 0.1f) // движение почти вертикальное
		 		{
					float collisionPointX = collision.contacts[0].point.x; // точка касания
					float playerCenterPosition = playerMove.gameObject.transform.position.x;
					float difference = playerCenterPosition - collisionPointX; // разница между центром вагонетки и местом касания
					float direction = collisionPointX < playerCenterPosition ? -1 : 1; // расчёт направления
					_ball.AddForce(direction * Mathf.Abs(difference));
				}
			}
			_lastPositionX = ballPositionX;

			if (collision.gameObject.TryGetComponent(out IDamageable damageable)) 
			{
				damageable.ApplyDamage();
			}
		}
	}
}


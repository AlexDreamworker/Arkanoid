using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class Weapon : Bonus
    {
		[SerializeField] private GameObject _bullet;
		private readonly List<GameObject> _bullets = new List<GameObject>();
		private const int AmountToPool = 20;
		private const float OffsetY = 0.5f;
		private const float OffsetX = 0.5f;
		
        public override void Apply()
        {
			StartTimer();
			StartCoroutine(StartShoot());
        }

		private void OnEnable()
		{
			CreatePool();
		}

		private void CreatePool()
		{
			_bullets.Clear();
			GameObject temp;
			for (var i = 0; i < AmountToPool; i++)
			{
				temp = Instantiate(_bullet);
				_bullet.SetActive(false);
				_bullets.Add(temp);
			}
		}

		private GameObject GetBullet() 
		{
			for (int i = 0; i < _bullets.Count; i++)
			{
				if (!_bullets[i].activeInHierarchy)
				{
					return _bullets[i];
				}
			}
			return null;
		}

		private IEnumerator StartShoot() 
		{
			while (true)
			{
				ActiveBullet(OffsetX);
				ActiveBullet(-OffsetX);
				yield return new WaitForSeconds(0.5f);
			}
		}

		private void ActiveBullet(float offsetX) 
		{
			GameObject bullet = GetBullet();
			if (bullet != null) 
			{
				bullet.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y + OffsetY);
				bullet.SetActive(true);
			}
		}
    }
}


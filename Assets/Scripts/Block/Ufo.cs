using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class Ufo : MonoBehaviour, IDamageable
    {
        public void ApplyDamage()
        {
            GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<BoxCollider2D>().enabled = false;
			GetComponent<ParticleSystem>().Play();
        }
    }
}


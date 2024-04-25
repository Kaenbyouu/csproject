using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EEL.RelativisticSpaceInvaders
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float speedOfBullet = 200f;

        [SerializeField]
        private float lifeTime = 5f;

        internal void selfDestruct()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            //GameCtrl.Instance.CreateExplosion(transform.position);
        }

        private void Awake()
        {
            Invoke("selfDestruct", lifeTime);
        }

        private void Update()
        {
            transform.Translate(speedOfBullet * Time.deltaTime * Vector2.up);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            selfDestruct();
        }

    }
}
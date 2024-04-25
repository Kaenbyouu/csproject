using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EEL.RelativisticSpaceInvaders
{
    public class BulletSpawner : MonoBehaviour
    {
        internal int currentRow;
        internal int column;

        [SerializeField]
        private GameObject bulletPrefab;

        [SerializeField]
        private Transform spawnPoint;

        [SerializeField]
        private float minTime;

        [SerializeField]
        private float maxTime;

        private float timer;
        private float currentTime;
        private Transform followTarget;

        internal void Setup()
        {
            currentTime = Random.Range(minTime, maxTime);
            followTarget = InvaderSpawner.Instance.GetInvader(currentRow, column);

        }

        private void OnCollisionEnter2D(Collision2D other)
        {

            if (!other.collider.GetComponent<Bullet>())
            {
                return;
            }
            //GameCtrl.UpdatePts();
            InvaderSpawner.Instance.IncDeathCount();
            followTarget.GetComponentInChildren<SpriteRenderer>().enabled = false;
            
            currentRow -= currentRow;
            if (currentRow < 0)
            {
                gameObject.SetActive(false);
            }
            else { Setup(); }

        }

       
        private void Update()
        {
            transform.position = followTarget.position;
            timer += Time.deltaTime;
            if (timer < currentTime) { return; } // causes delay.
            Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            timer = 0f;
            currentTime = Random.Range(minTime, maxTime);
        }
    }
}
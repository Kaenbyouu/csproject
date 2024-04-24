using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleGravityZones : MonoBehaviour
{
   [SerializeField]
   private float speedFactor = 0.2f;
   public float timer = 10f;

    private float oldSpeed;
    private GameObject player;
    private GameObject enemy;
    private GameObject bullet;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        oldSpeed = player.GetComponent<Player>().Speed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        player.GetComponent<Player>().Speed *= speedFactor;

        /*if (other.gameObject.tag == "Enemy")
        {
            oldSpeed = other.gameObject.GetComponent<Enemy>().Speed;
            other.gameObject.GetComponent<Enemy>().Speed *= speedFactor;
        }
        if (other.gameObject.tag == "bullet")
        {
            oldSpeed = other.gameObject.GetComponent<Bullet>().Speed;
            other.gameObject.GetComponent<Bullet>().Speed *= speedFactor;
        }*/

        if (speedFactor == 0.0f)
            {
             StartCoroutine(Timer(other.gameObject));
            }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        player.GetComponent<Player>().Speed = oldSpeed;

        /*if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().Speed = oldSpeed;
        }
        if (other.gameObject.tag == "bullet")
        {
            other.gameObject.GetComponent<Enemy>().Speed = oldSpeed;
        }*/

    }

    IEnumerator Timer(GameObject obj)
    {
        Debug.Log("TimerEnter");
        yield return new WaitForSeconds(timer);
        Debug.Log("timerEnded");
        Destroy(obj);
    }
}

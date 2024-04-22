using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleGravityZones : MonoBehaviour
{

   [SerializeField]
    private float mass = 1;

   [SerializeField]
   private float speedFactor = 0.2f;
   public float timer = 10f;

    private float oldSpeed;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        oldSpeed = player.GetComponent<Player>().Speed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        player.GetComponent<Player>().Speed *= speedFactor;

            if (speedFactor == 0)
            {
             Debug.Log("EventHorizon");
             StartCoroutine(Timer(player));
            }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        player.GetComponent<Player>().Speed = oldSpeed;
    }

    IEnumerator Timer(GameObject obj)
    {
        Debug.Log("TimerEnter");
        yield return new WaitForSeconds(timer);
        Debug.Log("timerEnded");
        Destroy(obj);
    }
}

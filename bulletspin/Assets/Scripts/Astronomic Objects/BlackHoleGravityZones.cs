using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleGravityZones : MonoBehaviour
{

   [SerializeField]
    private double mass = 1;

   [SerializeField]
    private double speedFactor = 0.2;

    private double oldSpeed;

    
    private void OnTriggerEnter2D(Collision2D other)
    {
        Debug.Log($"Enter");
        //oldSpeed = other.gameObject.speed;
        //other.gameObject.speed *= speedFactor;
    }
    private void OnTriggerExit2D(Collision2D other)
    {
        //other.gameObject.speed = oldSpeed;
        Debug.Log($"Exit");
    }
}

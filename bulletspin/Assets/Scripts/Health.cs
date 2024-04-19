using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int lives;

    private int health;

    void Start()
    {
        health = lives;
    }

    private void updateHealth()
    {
        health -= 1;

        Debug.Log("update");
        Debug.Log(health);

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("dead");
            Debug.Log(health);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        updateHealth();
        Debug.Log("crash");
    }
}

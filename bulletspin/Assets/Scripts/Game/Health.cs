using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    public float lives; //number of lives the player gets

    private float health;

    public Image Healthbar;


    void Start()
    {
        health = lives;
    }

    private void updateHealth()
    {
        health -= 1;

        Healthbar.fillAmount = Mathf.Clamp(health / lives, 0f, 1f);// updating health bar

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        updateHealth();
    }

    
}

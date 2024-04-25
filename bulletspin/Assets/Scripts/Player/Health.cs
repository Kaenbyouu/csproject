using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    public float maxHealth;
    private float currentHealth;
    public Image Healthbar;
    private Animator animator;
    public GameManager gameManager;
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.gameOver();
        }
    }
    public void TakeDamage(int amount)
    {
        if (currentHealth != 0)
        {
            currentHealth -= amount;

            Healthbar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0f, 1f);// updating health bar

            Debug.Log("damage taken");
            Debug.Log(currentHealth);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.SetTrigger("isDead");
                gameManager.gameOver();
                //Destroy(gameObject);
                Debug.Log("dead");

            }
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        Healthbar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0f, 1f);// updating health bar

        Debug.Log("healed");

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void deathAnimationFinished()
    {
        Destroy(gameObject);
    }


    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    updateHealth();
    //    Debug.Log("crash");
    //}
}

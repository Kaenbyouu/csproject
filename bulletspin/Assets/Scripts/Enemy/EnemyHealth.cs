using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public float maxHealth;
    private float currentHealth;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        Debug.Log("hit square");
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animator.SetTrigger("isDead");
            Debug.Log("square killed");
        }
    }
    public void deathAnimationFinished()
    {
        Destroy(gameObject);
    }
}

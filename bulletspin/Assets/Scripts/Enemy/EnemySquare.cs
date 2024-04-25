using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquare : MonoBehaviour
{
    public float speed;
    private Transform player;
    private float rot;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        Vector3 direction = player.transform.position - transform.position;
        rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot - 90);

        if (direction != Vector3.zero)
        {
            animator.SetBool("isFlying", true);
        }
        else
        {
            animator.SetBool("isFlying", false);
        }
    }

    public void stopFlyingAfterDeath()
    {
        speed = 0;
    }

}

using UnityEngine;

public class Enemy_Hexagon : MonoBehaviour
{
    private Transform player;
    private float rot;
    private Animator animator;

    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }
}

using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float Range;
    public float TimeBetweenShots;
    private float timer;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {


        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < Range)
        {
            timer += Time.deltaTime;

            if (timer > TimeBetweenShots)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    public void stopShootingAfterDeath()
    {
        TimeBetweenShots = 9;
    }
}

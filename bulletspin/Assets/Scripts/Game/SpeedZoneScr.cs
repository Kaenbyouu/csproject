using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedZoneScr : MonoBehaviour
{
    [SerializeField]
    public bool Relativity = false;

    [SerializeField]
    public float speedFactor = 2;

    public GameObject player;

    public GameObject enemyprojectiles;
    public GameObject PlayerProjectiles;
    public GameObject Invader;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"exit- SpeedzoneLog{other.tag}");
        if (other.gameObject.tag == "Player")
        {

            Player Player = player.GetComponent<Player>();
            Player.Speed += 4*speedFactor*speedFactor;

        }
        /*if (other.gameObject.tag == "bulletInvader")
        {

            Projectile Projectile = enemyprojectiles.GetComponent<Projectile>();
            Projectile.speed += 4 * speedFactor * speedFactor;

        }
        if (other.gameObject.tag == "bulletPlayer")
        {

            Projectile projectile = PlayerProjectiles.GetComponent<Projectile>();
            projectile.speed += 4 * speedFactor * speedFactor;

        }*/
        else
        {
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log($"exit- SpeedzoneLog{other.tag}");
            Player Player = player.GetComponent<Player>();
            Player.Speed -= 4 * speedFactor * speedFactor;

        }
        /*if (other.gameObject.tag == "bulletInvader")
        {

            Projectile Projectile = enemyprojectiles.GetComponent<Projectile>();
            Projectile.speed -= 4 * speedFactor * speedFactor;

        }
        if (other.gameObject.tag == "bulletPlayer")
        {

            Projectile projectile = PlayerProjectiles.GetComponent<Projectile>();
            projectile.speed -= 4 * speedFactor * speedFactor;

        }*/
        else
        {
            return;
        }
    }


}

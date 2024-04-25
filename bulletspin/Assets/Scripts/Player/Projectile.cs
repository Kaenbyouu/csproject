using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    private Rigidbody2D rb;


    private void Update()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody2D>();

        // Apply initial force in the specified direction
        rb.AddForce(direction * speed/100, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Enemy"))
        {
            var healthComponent = other.GetComponent<EnemyHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }
        }
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Destroy(this.gameObject);
    //} 

    //Debug.Log(other.tag);
    //if (other.gameObject.tag != "speedZone")
    //{
    //    Destroy(this.gameObject);
    //}
    //else
    //{
    //    return;
    //}



    ////__________________________ Self destruction of bullet, to avoid too many gameObjects; added by Eva

    //[SerializeField]
    //private float lifeTime = 5f;

    //internal void selfDestruct()
    //{
    //    gameObject.SetActive(false);
    //    Destroy(gameObject);
    //}
    //private void Awake()
    //{
    //    Invoke("selfDestruct", lifeTime);
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    this.destroyed.Invoke();
    //    Destroy (this.gameObject);
    //}
}
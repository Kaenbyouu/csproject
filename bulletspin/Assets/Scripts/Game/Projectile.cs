using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 60.0f;

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody2D>();

        // Apply initial force in the specified direction
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}

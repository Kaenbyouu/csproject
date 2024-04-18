using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;

    public float speed = 60.0f;


    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        

        //Debug.Log(other.tag);
        //if (other.gameObject.tag != "speedZone")
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //    return;
        //}
    }
    

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
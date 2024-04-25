using EEL.RelativisticSpaceInvaders;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    public GameCtrl GameCtrl;

    [SerializeField]
    public Projectile laserPrefab;

    [SerializeField]
    private Collider2D Collider;

    private Rigidbody2D playerRigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public GameManager gameManager;


    private Vector3 moveDir;
    private float MoveX = 0f;
    private float MoveY = 0f;
    public float Speed = 40.0f;

    private Vector3 shootDir;
    private float shootX = 0f;
    private float shootY = 0f;

    private float timer;
    public float timeBetweenFiring;

    private float zerosOnMyBankAcc = 0;

    private bool canFire;

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleMovement();

        Fire();


        // Debug.Log($"speed{Speed}");
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveX = 1f;
        }
        else
        {
            MoveX = 0f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveY = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveY = -1f;
        }
        else
        {
            MoveY = 0f;
        }

        moveDir = new Vector3(MoveX, MoveY).normalized;

        if (moveDir != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }


    private void Fire()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            shootX = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            shootX = 1f;
        }
        else
        {
            shootX = 0f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            shootY = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            shootY = -1f;
        }
        else
        {
            shootY = 0f;
        }

        shootDir = new Vector3(shootX, shootY).normalized;

        if (shootDir != new Vector3(0,0))
        {
            if (shootX < 0f)
            {
                spriteRenderer.flipX = true;
            } 
            else if (shootX > 0f)
            {
                spriteRenderer.flipX = false;
            }

            if (canFire)
            {
                Shoot();
            }
        }
     

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
    }

    private void Shoot()
    {
        canFire = false;
        Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
        projectile.direction = shootDir;
        animator.SetTrigger("shootGun");
    }


    // Collision handling based on diffrent tags: zones, invaders and bullets

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerRigidbody2D.MovePosition(transform.position + moveDir * Speed/2 * Time.fixedDeltaTime);
            //this.transform.position += moveDir * this.Speed / 2 * Time.deltaTime;
        }
        else
        {
            playerRigidbody2D.MovePosition(transform.position + moveDir * Speed * Time.fixedDeltaTime);
            //this.transform.position += moveDir * this.Speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("CollisionEnter");
        if (other.CompareTag("coin"))
        {
            zerosOnMyBankAcc += other.gameObject.GetComponent<Properties>().pts;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("booster"))
        {
            GetComponent<Itemcollection>().React(other.gameObject);
            zerosOnMyBankAcc += other.gameObject.GetComponent<Properties>().pts;

        }
    }




    //    private void OnCollisionEnter2D(Collision2D other)
    //    {
    //        if(other.gameObject.tag == "bullet") // || other.gameObject.tag == "invader"
    //        {
    //            GameCtrl.LiveUpdate();
    //            Debug.Log("HIT");
    //            Debug.Log(other.gameObject.tag);
    //        }
    //        if (other.gameObject.tag == "speedZone")
    //        {

    //            //speed = velocity;
    //            Debug.Log("bumpedd into speed zone");

    //        }
    //        else
    //        {
    //            return;
    //        }
    //    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : MonoBehaviour
{
    
    [SerializeField]public Rigidbody2D rb;
    public float hyppyVoima = 12;
    public float nopeus = 10;
    public LogicScript logic;
    public bool cowIsAlive = true;
    //private CircleCollider2D circleCollider2D;
    [SerializeField]public bool isGrounded = false;
    [SerializeField]Transform groundCheckCollider;
    const float groundCheckRadius = 0.2f;

    private float horizontal;
    public bool isFacingRight = true;


    [SerializeField]LayerMask groundLayer;


    // Tarkistaa, koskettaako pelihahmo maata
    // (isGrounded = true)  pelihahmo koskettaa maata
    // (isGrounded = false) pelihahmo ei kosketa maata
    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0 )
            isGrounded = true;
    }


    // Start is called before the first frame update
    void Start()
    {       
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }


    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        //// Hyppy
        //if (Input.GetKeyDown(KeyCode.Space) && cowIsAlive && isGrounded)
        //{ 
        //    rb.velocity = Vector2.up * hyppyVoima;
        //}

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && cowIsAlive)
        {
            rb.velocity = new Vector2(rb.velocity.x, hyppyVoima);
        }

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();



        // Liikutus
        //if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.Space) && cowIsAlive)
        //{
        //    rb.velocity = Vector2.right * nopeus;
        //    rb.velocity = Vector2.up * hyppyVoima;
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow) && cowIsAlive)
        //{
        //    rb.velocity = Vector2.right * nopeus;
        //}

        //if (Input.GetKeyDown(KeyCode.LeftArrow) && cowIsAlive)
        //{
        //    rb.velocity = Vector2.left * nopeus;
        //}
    }


    private void FixedUpdate()
    {
        if (cowIsAlive)
        {
            rb.velocity = new Vector2(horizontal * nopeus, rb.velocity.y);
        }
    }


    private void Flip()
    {
        if (cowIsAlive)
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
                {
                    isFacingRight = !isFacingRight;
                    Vector3 localScale = transform.localScale;
                    localScale.x *= -1f;
                    transform.localScale = localScale;
                }
        }
    }


    // Tarkistetaan törmäys
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "maaTagi")
        {
            Debug.Log("Maatägi tunnistettu");
            return;
        }
        
        
        cowIsAlive = false;
        logic.gameOver();
    }
}

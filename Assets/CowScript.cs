using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : MonoBehaviour
{
    
    public Rigidbody2D myRigidbody;
    public float pomppuNopeus = 12;
    public LogicScript logic;
    public bool cowIsAlive = true;
    //private CircleCollider2D circleCollider2D;
    [SerializeField]public bool isGrounded = false;
    [SerializeField]Transform groundCheckCollider;
    const float groundCheckRadius = 0.2f;

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
        //if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && cowIsAlive) 
        //{ 
        //    myRigidbody.velocity = Vector2.up * pomppuNopeus;

        //}

        // Hyppy
        if (Input.GetKeyDown(KeyCode.Space) && cowIsAlive && isGrounded)
        { 
            myRigidbody.velocity = Vector2.up * pomppuNopeus;

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
        logic.gameOver();
        cowIsAlive = false;
    }
}

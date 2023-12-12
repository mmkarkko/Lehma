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
 

    //private bool IsGrounded()
    //{
    //    float extraHeightText = .01f; // Toleranssia
    //    RaycastHit2D raycastHit = Physics2D.Raycast(circleCollider2D.bounds.center, Vector2.down, circleCollider2D.bounds.extents.y + extraHeightText);

    //    // Testataan testiviivan värillä, kosketaanko jotakin
    //    Color rayColor;
    //    if (raycastHit.collider != null)
    //    {
    //        rayColor = Color.green;
    //    } else
    //    {
    //        rayColor = Color.red;
    //    }
    //    Debug.DrawRay(circleCollider2D.bounds.center, Vector2.down * (circleCollider2D.bounds.extents.y + extraHeightText));

    //    return raycastHit.collider != null;
    //}

    // Start is called before the first frame update
    void Start()
    {
        
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

        //// Hyppy
        //if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && cowIsAlive) 
        //{ 
        //    myRigidbody.velocity = Vector2.up * pomppuNopeus;

        //}

        // Hyppy
        if (Input.GetKeyDown(KeyCode.Space) && cowIsAlive)
        { 
            myRigidbody.velocity = Vector2.up * pomppuNopeus;

        }

    }

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

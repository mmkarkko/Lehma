using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float pomppuNopeus = 12;
    public LogicScript logic;
    public bool cowIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && cowIsAlive) 
        { 
            myRigidbody.velocity = Vector2.up * pomppuNopeus;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        cowIsAlive = false;

    }
}

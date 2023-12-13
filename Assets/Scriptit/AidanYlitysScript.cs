using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidanYlitysScript : MonoBehaviour
{
    public LogicScript logic;
    public CowScript cow;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        cow   = GameObject.FindGameObjectWithTag("pelaaja").GetComponent<CowScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cow.cowIsAlive && collision.gameObject.layer == 3 && cow.isFacingRight)
        {
            logic.addScore(1);
        }
        
    }
}

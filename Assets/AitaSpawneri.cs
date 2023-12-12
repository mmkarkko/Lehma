using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AitaSpawneri : MonoBehaviour
{
    public GameObject aita;
    //public float spawnRate = 2;
    //private float timer = 0;
    //public float heightOffset = 10;
    private float targetTime;
    private float targetTimeAlaraja = 5;
    private float targetTimeYlaraja = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnAita();
        targetTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        // T�m� kutsuu spawnAita() aina samoin v�liajoin
        //if (timer < spawnRate)
        //{
        //    timer +=Time.deltaTime;
        //}
        //else 
        //{
        //    spawnAita();
        //    timer = 0;
        //}


        // Halutaan ajastin, joka kutsuu spawnAita() vaihtelevin v�liajoin, v�lill� x-y
        targetTime -= Time.deltaTime;
        if (targetTime <= 0 )
        {
            spawnAita();
            targetTime = Random.Range(targetTimeAlaraja, targetTimeYlaraja);
        }
        //Debug.Log("targetTime on " + targetTime);
        
    }

    void spawnAita()
    {
        //float lowestPoint  = transform.position.y - heightOffset;
        //float highestPoint = transform.position.x - heightOffset;
        //Instantiate(aita, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation); // Aidat spawnaa random-korkeudelle v�lill� lowestPoint-highestPoint

        Instantiate(aita, transform.position, transform.rotation); //aidat spawnaa aina samalle korkeudelle
        

        

    }

}

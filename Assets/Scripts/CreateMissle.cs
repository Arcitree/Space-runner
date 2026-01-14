using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMissle : MonoBehaviour
{
    public GameObject spawnee;
    private Boolean firstMiss = true;
    GameObject newMissle;
    public int misslecount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(misslecount > 0){ 
            if (firstMiss)
            {
                newMissle = Instantiate(spawnee, this.transform.position, Quaternion.identity) as GameObject;
                firstMiss = false;
            }
            else
            {
                firstMiss = true;
            }
                misslecount--;
        }

        }
    }
}

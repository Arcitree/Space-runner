using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMissle : MonoBehaviour
{
    public static float MissleSpeed = 1000;
 
    public ParticleSystem ps;
    ParticleSystem newps;
    public float InitialMissleSpeed;
    public float startsec;
    public MeshRenderer renderer;
    // Start is called before t   he first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * MissleSpeed;
    }
}

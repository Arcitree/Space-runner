using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    public float speed;
    float tempsped;
    public MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        tempsped = speed;
    }

    // Update is called once per frame
    void Update()
    {
        try { 
        if (renderer.material.color == Color.red)
        {
            transform.position += transform.forward * (2 * speed) * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * (speed) * Time.deltaTime;
        }
        }
        catch(MissingReferenceException e)
        {

        }

    }
}

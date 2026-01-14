using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    public Transform reference;
    public GameObject ship;
    public Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try { 
        transform.position = reference.position;
        if (renderer.material.color == Color.yellow)
        {
            gameObject.transform.localScale = new Vector3(7f, 5f, 5f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(15f, 10f, 10f);
        }
        }
        catch(MissingReferenceException e)
        {

        }
    }
}

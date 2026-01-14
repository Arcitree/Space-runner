using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShipControllor : MonoBehaviour
{
    Vector3 Vec;
    public int shield;
    public GameObject model;
    public Text myText;
    public ParticleSystem ParticleSystem;
    ParticleSystem ps;
    Color originalcolor;
    public MeshRenderer renderer;
    Quaternion bruh;
    Boolean hasbeenRed = true;
    Boolean hasbeenYellow = true;
    Boolean hasbeenOG = true;
    Boolean issmall = false;

    // Start is called before the first frame update
    void Start()
    {
        bruh = new Quaternion();
        bruh.eulerAngles = new Vector3(-10, 0, 0);
        originalcolor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(renderer.material.color == Color.yellow)
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
           gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "endpoint")
        {
            renderer.material.color = Color.green;
            myText.text = "You win!";
            myText.material.color = Color.green;
        }
        else if (collision.gameObject.tag != "missle") { 
        Debug.Log("Collision Entered");
            if (shield > 0)
            {
                shield--;
                myText.text = "Shields: " + shield;
                Physics.IgnoreCollision(model.gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>(), false);
              
            }
            else if (shield <= 0) {
            
                ps = Instantiate(ParticleSystem, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }
            if(shield == 0)
            {
                myText.color = Color.red;
            }
           
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }


}

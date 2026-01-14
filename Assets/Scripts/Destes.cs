using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destes : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    ParticleSystem ps;
    public int x, y, z;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.tag == "playership" || collision.gameObject.tag == "missle")
        { 
        ps = Instantiate(ParticleSystem, this.transform.position, this.transform.rotation);
        ps.transform.localScale = new Vector3(x, y, z);
        Destroy(this.gameObject);
    }
    }
}

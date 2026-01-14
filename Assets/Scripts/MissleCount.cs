using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissleCount : MonoBehaviour
{
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            count--;
            if(count>=0)
            this.gameObject.GetComponent<Text>().text = "Missle Count: " + count;

            if (count == 0)
            {
                this.gameObject.GetComponent<Text>().color = Color.red;
            }
    }
    }
}

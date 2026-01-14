using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AwardPoints : MonoBehaviour
{
    public static long points = 0;
    public Text myText;
    public MeshRenderer renderer;
    Boolean hasbeenRed = false;
    Boolean hasbeenWhite = false;
    Color og;
    Boolean hasbeenBlue = false;
    int powerturn = 1;

    // Update is called once per frame
    private void Start()
    {
        og = renderer.material.color;   
    }
    void Update()
    {
        //myText.text = "Score: " + points;

        if (Input.GetKey(KeyCode.Q))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Invoke("Power", 0f);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            renderer.material.color = og;
        }
    }
    void Power()
    {
        if(powerturn == 1)
        {
            renderer.material.color = Color.red;
            powerturn = 2;
        }
       else if(powerturn == 2)
        {
            renderer.material.color = Color.yellow;
            powerturn = 1;
        }
    }
}

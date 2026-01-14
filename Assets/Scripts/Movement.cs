using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Movement : MonoBehaviour
{
    Transform playermodel;
    public Renderer renderer;
    public float horizontalClamp;
    public float verticalClamp;
    public float playerspeed;
    public float lookingspeed;
    public float leanlimit;
    public float leantime;
    public Transform playerAim;
    public float centeredlength;
    // Start is called before the first frame update
    void Start()
    {
        playermodel = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (renderer.material.color == Color.red)
        {
            transform.localPosition += new Vector3(horizontal, vertical, 0) * (3 * playerspeed) * Time.deltaTime;
        }
        else
        {
            transform.localPosition += new Vector3(horizontal, vertical, 0) * playerspeed * Time.deltaTime;
        }

        Vector3 Vec = transform.localPosition;
        Vec.x = Mathf.Clamp(transform.localPosition.x, -horizontalClamp, horizontalClamp);
        Vec.y = Mathf.Clamp(transform.localPosition.y, -verticalClamp, verticalClamp);

        transform.localPosition = Vec;

        //Look towards centered object
        playerAim.parent.position = Vector3.zero;
        playerAim.localPosition = new Vector3(horizontal, vertical, centeredlength);
        if (renderer.material.color == Color.red) { 
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(playerAim.position), Mathf.Deg2Rad * (2*lookingspeed) * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(playerAim.position), Mathf.Deg2Rad * lookingspeed * Time.deltaTime);
        }
        //Lean when moving
        Vector3 targetAngle = playermodel.localEulerAngles;
        if (renderer.material.color == Color.red)
        {
            playermodel.localEulerAngles = new Vector3(targetAngle.x, targetAngle.y, Mathf.LerpAngle(targetAngle.z, -horizontal * (1.5f * leanlimit), (0.5f * leantime)));
        }
        else
        {
            playermodel.localEulerAngles = new Vector3(targetAngle.x, targetAngle.y, Mathf.LerpAngle(targetAngle.z, -horizontal * leanlimit, leantime));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(playerAim.position, .5f);
        Gizmos.DrawSphere(playerAim.position, .15f);
    }
}

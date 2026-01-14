using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = Vector3.zero;
    public Vector2 limits = new Vector2(0, 0);
    //Smoothtime only between 0 and 1
    public float smoothTime;
    public Vector3 speed = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try { 
        Vector3 loPos = transform.localPosition;
        Vector3 targetLoPos = target.transform.localPosition;
        transform.localPosition = Vector3.SmoothDamp(loPos, new Vector3(targetLoPos.x + offset.x, targetLoPos.y + offset.y, loPos.z), ref speed, smoothTime);
        }
        catch (MissingReferenceException e)
        {

        }
    }
    void LateUpdate()
    {
        Vector3 loPos = transform.localPosition;

        transform.localPosition = new Vector3(Mathf.Clamp(loPos.x, -limits.x, limits.x), Mathf.Clamp(loPos.y, -limits.y, limits.y), loPos.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-limits.x, -limits.y, transform.position.z), new Vector3(limits.x, -limits.y, transform.position.z));
        Gizmos.DrawLine(new Vector3(-limits.x, limits.y, transform.position.z), new Vector3(limits.x, limits.y, transform.position.z));
        Gizmos.DrawLine(new Vector3(-limits.x, -limits.y, transform.position.z), new Vector3(-limits.x, limits.y, transform.position.z));
        Gizmos.DrawLine(new Vector3(limits.x, -limits.y, transform.position.z), new Vector3(limits.x, limits.y, transform.position.z));
    }
}

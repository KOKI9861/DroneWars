using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraSmooth : MonoBehaviour
{

    private float zoom;
    public float zoomSpeed = 0.2f;
    public float zoomMin = 1, zoomMax = 5;

    public Transform target;
    public float smoothSpeed = 0.2f;
    public float smoothRotate = 0.4f;
    private float lookYUp;
    public Vector3 offset;
    Vector3 smoothedRotation;

    void Start()
    {
        GetComponent<Camera>().fieldOfView = 150f;
    }

    void Update()
    {
        if (GetComponent<Camera>().fieldOfView > 100f)
        {
            GetComponent<Camera>().fieldOfView -= 25f * Time.deltaTime;

        }
        if (GetComponent<Camera>().fieldOfView < 100f)
            GetComponent<Camera>().fieldOfView = 100f;
        Zoom();
        lookYUp = offset.y*0.5f;
        Vector3 desiredPosition = target.position + (target.up * offset.y + target.right * offset.x + target.forward * offset.z)*zoom;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.rotation = Quaternion.EulerAngles(target.eulerAngles.x, target.eulerAngles.y, target.eulerAngles.z);
        smoothedRotation = Vector3.Lerp(smoothedRotation,target.position + target.up * lookYUp + (transform.position - desiredPosition), smoothRotate);
        transform.LookAt(smoothedRotation);


    }

    void Zoom()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            zoom += zoomSpeed;
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            zoom -= zoomSpeed;
        }
        if (zoom > zoomMax) zoom = zoomMax;
        if (zoom < zoomMin) zoom = zoomMin;
        Debug.Log(zoom);
    }

}
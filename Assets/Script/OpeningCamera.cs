using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCamera : MonoBehaviour
{
    private float MouseRotateSpeed = 0.5f;
    private float CameraMaxDegree = 75;
    private float CameraMinDegree = 285;
    private Quaternion tmpRotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        transform.rotation = tmpRotate;
        transform.Rotate(0, Input.GetAxisRaw("Mouse X") * MouseRotateSpeed, 0);
        transform.Rotate(-Input.GetAxisRaw("Mouse Y") * MouseRotateSpeed, 0, 0);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);

        if (transform.localEulerAngles.x > CameraMaxDegree && transform.localEulerAngles.x <= 90)
        {
            transform.localEulerAngles = new Vector3(CameraMaxDegree, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        if (transform.localEulerAngles.x < CameraMinDegree && transform.localEulerAngles.x > 270)
        {
            transform.localEulerAngles = new Vector3(CameraMinDegree, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        tmpRotate = transform.rotation;

    }
}

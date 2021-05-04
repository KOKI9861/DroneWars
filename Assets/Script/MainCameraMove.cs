using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour {

    float zoom;
    float zoomMin = 8, zoomMax = 80;


    void Start () {
        GetComponent<Camera>().fieldOfView = 179f;
        zoom = -transform.position.z;
    }

	void Update () {
        if (GetComponent<Camera>().fieldOfView > 60f)
        {
            GetComponent<Camera>().fieldOfView -= (GetComponent<Camera>().fieldOfView - 99f) * Time.deltaTime;
            
        }
        if (GetComponent<Camera>().fieldOfView < 100f)
            GetComponent<Camera>().fieldOfView = 100f;

        Zoom();
        //Focus();
	}

    void Zoom()
    {
        if (Input.mouseScrollDelta.y != 0 && zoom > zoomMin && zoom < zoomMax)
        {
            zoom -= Input.mouseScrollDelta.y * 2f;
            transform.Translate(0, 0, Input.mouseScrollDelta.y * 2f);
            Debug.Log(zoom);
        }
        if (Input.mouseScrollDelta.y < 0 && zoom <= zoomMin)
        {
            zoom -= Input.mouseScrollDelta.y * 2f;
            transform.Translate(0, 0, Input.mouseScrollDelta.y * 2f);
            Debug.Log(zoom);
        }
        if (Input.mouseScrollDelta.y > 0 && zoom >= zoomMax)
        {
            zoom -= Input.mouseScrollDelta.y * 2f;
            transform.Translate(0, 0, Input.mouseScrollDelta.y * 2f);
            Debug.Log(zoom);
        }
    }

 //   public void Focus(){
 //       Camera.transform.position = MainCameraPivot.transform.position;
 //       Camera.transform.rotation = MainCameraPivot.transform.rotation;
	
	//}

}
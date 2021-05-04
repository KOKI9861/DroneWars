//このスクリプトはたぶんいらない

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonCamera : MonoBehaviour {

    // public PhotonView myPV;
    [SerializeField] private float startZoomIn = 3f;
    private float startZoomInTmp;

    float zoom, zoomMin, zoomMax;


    void Start () {
        // if(!myPV.isMine){
        //     // gameObject.SetActive(false);
        //     return;
        // }

        GetComponent<Camera>().fieldOfView = 177f;
        startZoomInTmp = startZoomIn;
        zoom = -transform.position.z;
        zoomMin = 10;
        zoomMax = 200;
    }

	void Update () {
        // if(!myPV.isMine){
        //     return;
        // }

        if (GetComponent<Camera>().fieldOfView > 60f)
        {
            GetComponent<Camera>().fieldOfView -= startZoomIn * 1.2f;
            startZoomIn = startZoomIn * 0.99f / startZoomInTmp;
        }
        if (GetComponent<Camera>().fieldOfView < 60f)
            GetComponent<Camera>().fieldOfView = 60f;

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
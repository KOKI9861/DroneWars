//このスクリプトはたぶんいらない

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonCameraPivot : MonoBehaviour {

    public PhotonView myPV;
	public GameObject MainCameraPivot;
	float zoom, zoomMin, zoomMax;

	void Start () {
        if(!myPV.isMine){
            return;
        }

		// MainCameraPivot = GameObject.Find ("MainCameraPivot");
		zoom = -transform.position.z;
		zoomMin = 10;
		zoomMax = 200;
	}

	void Update () {
        if(!myPV.isMine){
            return;
        }

		Zoom ();
	}

	void Zoom(){
		if (Input.mouseScrollDelta.y != 0 && zoom > zoomMin && zoom < zoomMax) {
			zoom -= Input.mouseScrollDelta.y * 2f;
			MainCameraPivot.transform.Translate(0,0,Input.mouseScrollDelta.y * 2f);
			Debug.Log (zoom);
		}
		if (Input.mouseScrollDelta.y < 0 && zoom <= zoomMin ) {
			zoom -= Input.mouseScrollDelta.y * 2f;
			MainCameraPivot.transform.Translate(0,0,Input.mouseScrollDelta.y * 2f);
			Debug.Log (zoom);
		}
		if (Input.mouseScrollDelta.y > 0 && zoom >= zoomMax ) {
			zoom -= Input.mouseScrollDelta.y * 2f;
			MainCameraPivot.transform.Translate(0,0,Input.mouseScrollDelta.y * 2f);
			Debug.Log (zoom);
		}
	}
}

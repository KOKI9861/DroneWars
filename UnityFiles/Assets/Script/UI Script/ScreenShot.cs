using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ScreenShot : MonoBehaviour {

    public Text _ScreenShotResult;
    public GameObject _ScreenShotPanel;
    private float timer;
    public String save_Folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftAlt))
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                try
                {
                    ScreenCapture.CaptureScreenshot(save_Folder + "\\" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
                    _ScreenShotResult.text = "ScreenShot Path : " + save_Folder+ "\\" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
                }
                catch (Exception e)
                {
                    _ScreenShotResult.text = "ScreenShot Result : Fail";
                }
                timer = Time.realtimeSinceStartup;
            }
        }
        if (Time.realtimeSinceStartup - timer < 3f && 1f< Time.realtimeSinceStartup-timer && Time.realtimeSinceStartup>4f)
        {
            _ScreenShotPanel.gameObject.SetActive(true);
        }
        else
        {
            _ScreenShotPanel.gameObject.SetActive(false);
        }
    }
}

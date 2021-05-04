using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    void Start()
    {
        Cursor.visible = true;
    }

    //public string sceneName = "SingleStage1";

    public void LoginButton()
    {
        GameObject.Find("Canvas").transform.Find("TitleMenu").gameObject.active = false;
        GameObject.Find("Canvas").transform.Find("MainMenu").gameObject.active = true;
    }
    public void ClickStart()
    {
        Debug.Log("Start");
        GameManager.isPause = false;
        SceneManager.LoadScene("SingleStage1");
    }
    public void ClickRecord()
    {
        Debug.Log("Record");
    }
    public void ClickSetting()
    {
        Debug.Log("Setting");
    }
    public void ClickExit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}

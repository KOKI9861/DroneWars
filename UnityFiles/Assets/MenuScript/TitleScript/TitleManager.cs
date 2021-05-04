using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TitleManager : MonoBehaviour
{
    // public string userName = "nanashi";

    // public GameObject MoveLogInBtn;
    // public GameObject MoveSignUpBtn;
    // public GameObject MoveExitBtn;

    public GameObject ButtonPanel;
    public GameObject LogInPanel;
    public GameObject SignUpPanel;

    public static Vector3 btnScale;

    void Start() {
        Screen.SetResolution(GameManager.width, GameManager.height, Screen.fullScreen);
        QualitySettings.SetQualityLevel(GameManager.quality, true);
        // ボタンが押された時に呼ばれるメソッドの指定
        // MoveLogInBtn.GetComponent<Button>().onClick.AddListener(ClickLogIn);
        // MoveSignUpBtn.GetComponent<Button>().onClick.AddListener(ClickSignUp);
        // MoveExitBtn.GetComponent<Button>().onClick.AddListener(ClickExit);

        LogInPanel.SetActive(false);
        SignUpPanel.SetActive(false);

        btnScale = ButtonPanel.transform.Find("LogInButton").transform.localScale;
    }

    void Update(){

    }


    

    public void ClickLogIn(){
        Debug.Log("clickLogInBtn");

        ButtonPanel.SetActive(false);
        LogInPanel.SetActive(true);
    }

    public void ClickSignUp(){
        Debug.Log("clickSignUpBtn");

        ButtonPanel.SetActive(false);
        SignUpPanel.SetActive(true);
    }

    public void ClickExit()
    {
        Debug.Log("clickExitBtn");
        Application.Quit();
    }




}

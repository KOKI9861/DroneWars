using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TopPageManager : MonoBehaviour
{
    

    // public NCMBManagerScript ncmbScript;

    public Button SinglePlayBtn;
    public Button MultiPlayBtn;
    public Button RecordBtn;
    public Button TutorialBtn;
    public Button SettingBtn;
    public Button LogOutBtn;
    public GameObject ConnectingPanel;
    public GameObject RecordPanel;
    public GameObject SelectGameModePanel;
    public GameObject TutorialCanvas;
    public GameObject SettingCanvas;
    public Button MoveExitBtn;



    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(GameManager.width, GameManager.height, Screen.fullScreen);
        QualitySettings.SetQualityLevel(GameManager.quality, true);
        //ログインされていなかったらTitleに戻る
        if (!NCMBManagerScript.getSuccessConnect()){
            SceneManager.LoadScene("Title");
            return;
        }

        Debug.Log("OnlineFlag:"+PlayerInformation.OnlineFlag);
        //既にPhotonにつながっている場合接続を切る
        if(PlayerInformation.OnlineFlag){
            PhotonManagerScript.Disconnect();
            PlayerInformation.OnlineFlag = false;
            Debug.Log("OnlineFlag:"+PlayerInformation.OnlineFlag);
        }
        


        // クリックしたときに呼ばれる関数の設定
        SinglePlayBtn.onClick.AddListener(ClickSinglePlay);
        MultiPlayBtn.onClick.AddListener(ClickMultiPlay);
        RecordBtn.onClick.AddListener(ClickRecord);
        TutorialBtn.onClick.AddListener(ClickTutorial);
        SettingBtn.onClick.AddListener(ClickSetting);
        LogOutBtn.onClick.AddListener(ClickLogOut);
        MoveExitBtn.onClick.AddListener(ClickExit);

        // パネルの非表示
        ConnectingPanel.SetActive(false);
        RecordPanel.SetActive(false);
        SelectGameModePanel.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {

    }

    //以下クリックされたボタンそれぞれの処理
    void ClickSinglePlay(){
        Debug.Log("clicksingle");
        SelectGameModePanel.SetActive(true);
    }

    void ClickMultiPlay(){
        Debug.Log("clickmulti");
        ConnectingPanel.SetActive(true);

        // Photonに接続
        if(!PlayerInformation.OnlineFlag){
            // PhotonNetwork.ConnectUsingSettings("test");
            PhotonManagerScript.ConnectUsingSettings();
            Debug.Log("Photonに接続しました");
            PlayerInformation.OnlineFlag = true;
            Debug.Log("OnlineFlag:"+PlayerInformation.OnlineFlag);
        }
    }

    void ClickRecord(){
        Debug.Log("clickrecord");
        RecordPanel.SetActive(true);
        
    }

    void ClickTutorial(){
        Debug.Log("clicktutorial");
        TutorialCanvas.SetActive(true);
    }

    void ClickSetting(){
        Debug.Log("clicksetting");
        SettingCanvas.SetActive(true);
        if (Screen.fullScreen) GameObject.Find("FullScreen").GetComponent<Toggle>().isOn = true;
        else GameObject.Find("FullScreen").GetComponent<Toggle>().isOn = false;
    }

    void ClickLogOut(){
        Debug.Log("clickLogOut");
        NCMBManagerScript.logOut();
        SceneManager.LoadScene("Title");
    }
    void ClickExit()
    {
        Debug.Log("clickExitBtn");
        Application.Quit();
    }
    public void ClickReturnOnTutorialCanvas()
    {
        TutorialCanvas.SetActive(false);
    }
    public void ClickReturnOnSettingCanvas()
    {
        SettingCanvas.SetActive(false);
    }


    // public void OnFailedToConnectToPhoton(object parameters)
    // {
    //     // this.connectFailed = true;
    //     Debug.Log("OnFailedToConnectToPhoton. StatusCode: " + parameters + " ServerAddress: " + PhotonNetwork.ServerAddress);
    //     Debug.Log("接続に失敗しました。");
    // }

    // public override void OnJoinedLobby(){
    //     Debug.Log("ロビーに入りました");
    //     PhotonNetwork.LoadLevel("OnlineRoom");

    // }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WaintingRoomManagerScript : Photon.PunBehaviour
{
    public GameObject PlayerPrefab;
    private GameObject Player;

    public Text Member;
    public Text Player1;
    public Text Player2;
    public Text Player3;
    public Text Player4;
    
    // public Text MemberList;

    public Text RoomTitle;
    public Text NumOfPlayers;
    public Button ReadyButton;
    public Button LeaveButton;
    public Text PlayerInfo;


    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(GameManager.width, GameManager.height, Screen.fullScreen);
        QualitySettings.SetQualityLevel(GameManager.quality, true);
        if (!PhotonNetwork.connected){//Photon未接続なら
            SceneManager.LoadScene("TopPage");
            return;
        }
        //Photonに接続されていれば自キャラを生成
        float x = Random.Range(-50f,51f);
        float y = Random.Range(0f,51f);
        Player = PhotonManagerScript.Instantiate(this.PlayerPrefab, new Vector3(x,y,0f), Quaternion.identity);

        //カスタムプロパティ
        ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();
        customProp.Add("Ready", false);
        PhotonNetwork.player.SetCustomProperties(customProp);
        ReadyButton.interactable = true;


        //各ボタン設定
        ReadyButton.onClick.AddListener(ClickReady);
        LeaveButton.onClick.AddListener(ClickLeave);

        //ルーム情報を記述
        RoomTitle.text = "Room名:"+PhotonNetwork.room.name;
        
    }

    // Update is called once per frame
    void Update()
    {
        //ローカルプレイヤーの情報を記述（確認用）
        PlayerInfo.text = PhotonNetwork.player.ToString()+" id:"+PhotonNetwork.player.ID;

        NumOfPlayers.text = PhotonNetwork.playerList.Length+"人 / "+PhotonNetwork.room.MaxPlayers+"人";
        printMember();
        if(checkReady()){
            if(PhotonNetwork.player.IsMasterClient){
                ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();
                customProp.Add("Playing", true);
                PhotonNetwork.room.SetCustomProperties(customProp);
            }
            SceneManager.LoadScene("MultiStage1");
        }
    }

    void ClickReady(){
        //カスタムプロパティ
        GameManager.single_multi = "multi";
        ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();
        customProp.Add("Ready", true);
        PhotonNetwork.player.SetCustomProperties(customProp);
        ReadyButton.interactable = false;
    }

    void ClickLeave(){
        ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();
        customProp.Add("Ready", false);
        PhotonNetwork.player.SetCustomProperties(customProp);
        ReadyButton.interactable = true;

        PhotonManagerScript.LeaveRoom(Player);
        SceneManager.LoadScene("OnlineRoom");
    }

    void printMember(){
        //トップはローカルプレイヤ
        Member.transform.GetChild(0).gameObject.GetComponent<Text>().text = PhotonNetwork.player.name;
        changeColor(Member.transform.GetChild(0).gameObject,(bool)PhotonNetwork.player.CustomProperties["Ready"]);//Readyの状態で色が変わる

        //トップ以降は他プレイヤの名前が入る
        //始めに名前部分を空にしてプレイヤがいる分だけ書き込む
        for(int i=1;i<4;i++){
            Member.transform.GetChild(i).gameObject.GetComponent<Text>().text = "";
        }

        for(int i=0;i<PhotonNetwork.otherPlayers.Length;i++){
            Member.transform.GetChild(i+1).gameObject.GetComponent<Text>().text = PhotonNetwork.otherPlayers[i].name;
            
            changeColor(Member.transform.GetChild(i+1).gameObject,(bool)PhotonNetwork.playerList[i].CustomProperties["Ready"]);
            
        }
    }

    void changeColor(GameObject playerObject,bool ready){
        if(ready){
            playerObject.GetComponent<Text>().color = new Color32(0,255,0,255);//緑になる
        }else{
            playerObject.GetComponent<Text>().color = new Color32(255,0,0,255);//赤になる
        }
    }

    //全員がReadyを押したらtrueを返す
    bool checkReady(){
        int readyCount = 0;
        for(int i=0;i<PhotonNetwork.playerList.Length;i++){
            if((bool)PhotonNetwork.playerList[i].CustomProperties["Ready"]){
                readyCount++;
            }
        }

        if(readyCount == PhotonNetwork.room.MaxPlayers){
            return true;
        }
        
        return false;
    }

    
}

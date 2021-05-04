using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomManagerScript : Photon.PunBehaviour
{
    private string log = "";
    private bool connectFailed;
    public Button EnterRandomBtn;
    public Button MakeRoomBtn;
    public InputField SearchRoomField;
    public Button SearchBtn;
    public Button ReturnBtn;

    

    public GameObject MakeRoomPanel;


    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(GameManager.width, GameManager.height, Screen.fullScreen);
        QualitySettings.SetQualityLevel(GameManager.quality, true);
        // マルチは難易度設定まだないので、仮だけど、難易度をEXPERTにしておく。
        // GameManager.difficulty = "expert";
        // GameManager.difficulty = "online";
        GameManager.difficulty = "easy";

        if(!PhotonNetwork.connected){
            SceneManager.LoadScene("TopPage");
            return;
        }

        //各ボタンが押されたときに呼ばれるメソッドを指定
        EnterRandomBtn.onClick.AddListener(ClickEnterRandom);
        MakeRoomBtn.onClick.AddListener(ClickMakeRoom);
        SearchBtn.onClick.AddListener(ClickSearch);
        ReturnBtn.onClick.AddListener(ClickReturn);


        

        //Panelの非アクティブ化
        MakeRoomPanel.SetActive(false);

        // getRoomList();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.Return)) {
            ClickSearch();
        }
    }


    // 以下各ボタンクリック時の動作
    #region ButtonMethod
    void ClickEnterRandom(){
        Debug.Log("clickEnterRandom");
        //ランダムで部屋を選び、部屋に入る
        PhotonManagerScript.JoinRandomRoom();
    }

    void ClickMakeRoom(){
        Debug.Log("clickMakeRoom");
        MakeRoomPanel.SetActive(true);
    }

    void ClickSearch(){
        Debug.Log("clickSearch");
        // RoomSearch();
        OnReceivedRoomListUpdate();
    }

    void ClickReturn(){
        PhotonManagerScript.Disconnect();
        SceneManager.LoadScene("TopPage");
    }
    
    #endregion




    // 部屋情報が更新されたら呼び出される
    // 検索窓に書かれている文字列を含むもののみ表示
    // 検索窓が空欄ならすべての部屋を表示
    void OnReceivedRoomListUpdate(){
        string searchRoomName = SearchRoomField.text;

        GameObject Content = GameObject.Find("Canvas/Scroll View/Viewport/Content");
        
        // 今一覧に表示されているものを削除
        for( int i = Content.transform.childCount - 1; i >= 0; --i ){
			GameObject.DestroyImmediate( Content.transform.GetChild( i ).gameObject );
		}


        //ルーム一覧を取る
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        if (rooms.Length == 0) {
            Debug.Log ("ルームが一つもありません");
            EnterRandomBtn.interactable = false; //ルームがない場合ランダムに入るルームもないためボタンを押せないようにする
            
        } else {
            for (int i = 0; i < rooms.Length; i++) {
                if(rooms[i].playerCount < rooms[i].maxPlayers && !(bool)rooms[i].CustomProperties["Playing"]){ //ルームにいるプレイヤーの数が上限に達していない かつ　Stageに移行していない場合

                    if(rooms[i].name.Contains(searchRoomName)){
                        Debug.Log ("RoomName:"   + rooms [i].name);
                        GameObject RoomPrefab = (GameObject)Resources.Load("Prefab/Room");
                        
                        Text RoomName = RoomPrefab.transform.Find("RoomName").GetComponent<Text>();
                        RoomName.text = rooms[i].name;

                        Text Status = RoomPrefab.transform.Find("Status").GetComponent<Text>();
                        Status.text = rooms[i].PlayerCount +"人 / "+rooms[i].MaxPlayers +"人";
                        

                        Instantiate(RoomPrefab,Content.transform);

                    }   

                }
                            
                
                
            }
            EnterRandomBtn.interactable = true;

        }

    }




    // // 以下Photonのoverride
    // #region Photon Override

    // // 部屋に入ったときに呼ばれる
    // public override void OnJoinedRoom(){
    //     Debug.Log("部屋:"+PhotonNetwork.room.name+" に入りました");
    //     //対戦シーンをロード
    //     PhotonNetwork.LoadLevel("MultiStage1");
    // }

    // // 部屋づくりに失敗したとき
    // public void OnPhotonCreateRoomFailed()
    // {
    //     log = "Error: Can't create room (room name maybe already used).";
    //     Debug.Log("OnPhotonCreateRoomFailed got called. This can happen if the room exists (even if not visible). Try another room name.");
    // }

    // // 部屋に入れなかったとき
    // public void OnPhotonJoinRoomFailed(object[] cause)
    // {
    //     log = "Error: Can't join room (full or unknown room name). " + cause[1];
    //     Debug.Log("OnPhotonJoinRoomFailed got called. This can happen if the room is not existing or full or closed.");
    // }

    // // ランダムに部屋を選べないとき
    // public void OnPhotonRandomJoinFailed()
    // {
    //     log = "Error: Can't join random room (none found).";
    //     Debug.Log("OnPhotonRandomJoinFailed got called. Happens if no room is available (or all full or invisible or closed). JoinrRandom filter-options can limit available rooms.");
    //     //部屋を作成して、部屋に入る
    //     // PhotonManagerScript.CreateRoom("Room");
    // }

    // // 部屋を作るとき
    // public void OnCreatedRoom()
    // {
    //     Debug.Log("部屋:"+PhotonNetwork.room.name+" を作りました");
    //     PhotonNetwork.LoadLevel("MultiStage1");
    // }

    // // Photonとの接続が切れたとき
    // public void OnDisconnectedFromPhoton()
    // {
    //     Debug.Log("Disconnected from Photon.");
    //     PhotonNetwork.LoadLevel("TopPage");

    // }

    // public void OnFailedToConnectToPhoton(object parameters)
    // {
    //     this.connectFailed = true;
    //     Debug.Log("OnFailedToConnectToPhoton. StatusCode: " + parameters + " ServerAddress: " + PhotonNetwork.ServerAddress);
    // }

    // public void OnConnectedToMaster()
    // {
    //     Debug.Log("As OnConnectedToMaster() got called, the PhotonServerSetting.AutoJoinLobby must be off. Joining lobby by calling PhotonNetwork.JoinLobby().");
    //     PhotonNetwork.JoinLobby();
    // }

    // #endregion
}

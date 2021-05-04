using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PhotonManagerScript : Photon.PunBehaviour
{
    static string _gameVersion = "test"; //例えばバージョンアップしたときにここを変えると旧バージョンとは別のロビーに入る


    void Start(){
        DontDestroyOnLoad(this.gameObject);
    }

    public static void ConnectUsingSettings(){
        PhotonNetwork.ConnectUsingSettings(_gameVersion);
        // Debug.Log("Photonに接続しました");
    }

    //ルームを作成する
    public static void CreateRoom(string RoomName,int NumOfPlayers){
        
        PhotonNetwork.autoCleanUpPlayerObjects = false;
        //カスタムプロパティ
        // ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();
        // customProp.Add ("RoomName", RoomName); //ルーム名
        // PhotonNetwork.SetPlayerCustomProperties(customProp);

        

        // Debug.Log("int:"+NumOfPlayers+" byte:"+(byte)NumOfPlayers);
        RoomOptions roomOptions = new RoomOptions (){
            MaxPlayers = (byte)NumOfPlayers, // 部屋の最大人数
            IsOpen = true, // 入室を許可
            IsVisible = true, // ロビーから見えるようにする
            // ロビーで見える情報
            CustomRoomProperties = new ExitGames.Client.Photon.Hashtable(){{"Playing",false}}, // Stageに移行しているかどうか、FalseならまだWaitingRoom
            CustomRoomPropertiesForLobby = new string[]{"Playing"}

        };


        // roomOptions.customRoomProperties = customProp;
        // //ロビーで見えるルーム情報としてカスタムプロパティのRoomNameを使いますよという宣言
        // roomOptions.customRoomPropertiesForLobby = new string[]{"RoomName"};
        // roomOptions.maxPlayers = 4; //部屋の最大人数
        // roomOptions.isOpen = true; //入室許可する
        // roomOptions.isVisible = true; //ロビーから見えるようにする
        //RoomNameが名前のルームがなければ作って入室、あれば普通に入室する。
        // PhotonNetwork.JoinOrCreateRoom (RoomName, roomOptions, null);
        Debug.Log("heyatukuru");
        
        PhotonNetwork.CreateRoom(RoomName,roomOptions,null);
    }

    //ルームに参加する
    public static void JoinRoom(string RoomName){
        PhotonNetwork.JoinRoom(RoomName);
    }

    public static void JoinRandomRoom(){
        PhotonNetwork.JoinRandomRoom();
    }

    //ルームを退室する
    public static void LeaveRoom(GameObject myobject){
        PhotonNetwork.Destroy(myobject);
        PhotonNetwork.LeaveRoom();
    }

    //ロビーから出る
    public static void LeaveLobby(){
        PhotonNetwork.LeaveLobby();
    }

    //接続を切る
    public static void Disconnect(){
        PhotonNetwork.Disconnect();
    }

    public static GameObject Instantiate(GameObject gameobject, Vector3 position, Quaternion rotate){
        return PhotonNetwork.Instantiate(gameobject.name,position,rotate,0);
    }

    //InstantiateSceneObject
    public static GameObject InstantiateSceneObject(GameObject gameobject, Vector3 position, Quaternion rotate){
        return PhotonNetwork.InstantiateSceneObject(gameobject.name,position,rotate,0,null);
    }

    public static void Destroy(GameObject gameobject){
        PhotonNetwork.Destroy(gameobject);
    }




    //override
    //以下Photonのoverride
    public void OnFailedToConnectToPhoton(object parameters)
    {
        // this.connectFailed = true;
        Debug.Log("OnFailedToConnectToPhoton. StatusCode: " + parameters + " ServerAddress: " + PhotonNetwork.ServerAddress);
        Debug.Log("接続に失敗しました。");
    }

    public override void OnJoinedLobby(){
        Debug.Log("ロビーに入りました");
        PhotonNetwork.LoadLevel("OnlineRoom");
        
    }

    // 部屋に入ったときに呼ばれる
    public override void OnJoinedRoom(){
        Debug.Log("部屋:"+PhotonNetwork.room.name+" に入りました");
        //対戦シーンをロード
        // PhotonNetwork.LoadLevel("MultiStage1");
        PhotonNetwork.LoadLevel("WaitingRoom");
    }

    // 部屋づくりに失敗したとき
    public void OnPhotonCreateRoomFailed()
    {
        Debug.Log("OnPhotonCreateRoomFailed got called. This can happen if the room exists (even if not visible). Try another room name.");
        GameObject.Find("MakeRoomPanel").transform.Find("MessageField").GetComponent<Text>().text = "ルームを作成できませんでした\nすでにその名前のルームがある可能性があります";
    }

    // 部屋に入れなかったとき
    public void OnPhotonJoinRoomFailed(object[] cause)
    {
        Debug.Log("OnPhotonJoinRoomFailed got called. This can happen if the room is not existing or full or closed.");
    }

    // ランダムに部屋を選べないとき
    public void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed got called. Happens if no room is available (or all full or invisible or closed). JoinrRandom filter-options can limit available rooms.");
        //部屋を作成して、部屋に入る
        // CreateRoom("Room");
    }
    
    // ルームを作るとき
    public void OnCreatedRoom()
    {
        Debug.Log("部屋:"+PhotonNetwork.room.name+" を作りました");
        // PhotonNetwork.LoadLevel("MultiStage1");
        PhotonNetwork.LoadLevel("WaitingRoom");
    }

    // ルームを退室したとき
    public void OnLeftRoom(){
        Debug.Log("ルームから退室しました");
    }

    // Photonとの接続が切れたとき
    public void OnDisconnectedFromPhoton()
    {
        Debug.Log("Disconnected from Photon.");
        if(GameManager.gameEnd == 0){
            PhotonNetwork.LoadLevel("TopPage");
        }
    }


    public void OnConnectedToMaster()
    {
        Debug.Log("As OnConnectedToMaster() got called, the PhotonServerSetting.AutoJoinLobby must be off. Joining lobby by calling PhotonNetwork.JoinLobby().");
        PhotonNetwork.JoinLobby();
    }
}

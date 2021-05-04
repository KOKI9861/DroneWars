using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MakeRoomScript : MonoBehaviour
{
    private bool connectFailed;
    public GameObject MakeRoomPanel;
    public InputField RoomNameField;
    public Button MakeBtn;
    public Button ReturnOnlineRoomBtn;
    public Text MessageField;

    // Start is called before the first frame update
    void Start()
    {
        MessageField.text = "ルーム名とチーム人数を決めてください";

        MakeBtn.onClick.AddListener(ClickMake);
        ReturnOnlineRoomBtn.onClick.AddListener(ClickReturnOnlineRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ClickMake(){
        Debug.Log("clickMake");
        string RoomName = RoomNameField.text;
        int NumOfPlayers = NumToggleScript.NumOfPlayers;//トグルの場所に応じて部屋の最大人数を決定する
        if(RoomName == "" || NumOfPlayers == -1){
            MessageField.text = "入力が不十分です";
            return;
        }else{
            MessageField.text = "部屋"+RoomName+" "+NumOfPlayers+"人を作成します";
            PhotonManagerScript.CreateRoom(RoomName,NumOfPlayers);
        }
    }

    void ClickReturnOnlineRoom(){
        Debug.Log("clickReturn");
        MakeRoomPanel.SetActive(false);
        MessageField.text = "ルーム名とチーム人数を決めてください";

    }


    

}

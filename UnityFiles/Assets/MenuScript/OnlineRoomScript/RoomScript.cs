using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomScript : MonoBehaviour
{
    public Text RoomName;
    public Text Status;
    public Button JoinRoomBtn;

    // Start is called before the first frame update
    void Start()
    {
        JoinRoomBtn.onClick.AddListener(ClickJoinRoomBtn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickJoinRoomBtn(){
        PhotonManagerScript.JoinRoom(RoomName.text);
    }
}

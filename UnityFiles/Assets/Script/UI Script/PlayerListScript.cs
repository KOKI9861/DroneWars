using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerListScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Room").gameObject.GetComponent<Text>().text = PhotonNetwork.room.name;
    }

    // Update is called once per frame
    void Update()
    {
        printMember();
    }

    void printMember(){
        transform.GetChild(0).gameObject.GetComponent<Text>().text = PhotonNetwork.player.name;

        for(int i=1;i<4;i++){
            transform.GetChild(i).gameObject.GetComponent<Text>().text = "";
        }

        for(int i=0;i<PhotonNetwork.otherPlayers.Length;i++){
            transform.GetChild(i+1).gameObject.GetComponent<Text>().text = PhotonNetwork.otherPlayers[i].name;
            
        }
    }
}

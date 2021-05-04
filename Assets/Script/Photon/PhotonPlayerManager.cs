using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonPlayerManager : MonoBehaviour
{
    public PhotonView PV;
    public GameObject PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        //自分の生成したプレイヤーでなかったら
        if(!PV.isMine){
            PlayerCamera.SetActive(false);
            GetComponent<PlayerBulletInit>().enabled = false;
            GetComponent<PlayerMove>().enabled = false;
            // GetComponent<PhotonPlayerBullet>().enabled = false;
            // GetComponent<PhotonPlayerMove>().enabled = false;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

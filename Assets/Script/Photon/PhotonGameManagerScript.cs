using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PhotonGameManagerScript : Photon.PunBehaviour
{
    //誰かがログインするたびに生成するプレイヤープレハブ
    public GameObject PlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if(!PhotonNetwork.connected){
            SceneManager.LoadScene("TopPage");
            return;
        }
        
        //Photonに接続されていれば自キャラを生成
        float x = Random.Range(-50f,51f);
        float y = Random.Range(0f,51f);
        GameObject Player = PhotonManagerScript.Instantiate(this.PlayerPrefab, new Vector3(x,y,0f), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

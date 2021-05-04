using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSet : MonoBehaviour
{
    private GameObject clearPanel, gameoverPanel;
    private float pauseCounter;
    void Start()
    {
        GameManager.inGame = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseCounter = 0f;
    }
    void Update()
    {
        if (GameManager.gameEnd == -1)
        {
            GameOver();
        }
        if (GameManager.gameEnd == 1)
        {
            Clear();
        }
    }

    private void Clear()
    {
        clearPanel = GameObject.Find("StageCanvas").transform.Find("ClearPanel").gameObject;
        clearPanel.active = true;
        pauseCounter += Time.deltaTime;
        if(pauseCounter > 1.5f)
            Time.timeScale = 0f;
        GameManager.isPause = true;
        clearPanel.SetActive(true);
        Cursor.visible = true;

        if(PlayerInformation.OnlineFlag){//オンライン対戦ならPhoton通信を切る
            PhotonManagerScript.Disconnect();
        }
    }

    private void GameOver()
    {
        gameoverPanel = GameObject.Find("StageCanvas").transform.Find("GameoverPanel").gameObject;
        gameoverPanel.active = true;
        Time.timeScale = 0f;
        GameManager.isPause = true;
        gameoverPanel.SetActive(true);
        Cursor.visible = true;

        if(PlayerInformation.OnlineFlag){//オンライン対戦ならPhoton通信を切る
            PhotonManagerScript.Disconnect();
        }
    }

}

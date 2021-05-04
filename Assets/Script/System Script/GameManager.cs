using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool canPlayerMove = true;
    public static bool inGame = false;
    public static bool isPause = false;
    public static float deltaTimer;
    public static int keySet = 0;
    public static int gameEnd = 0; // 1:clear -1:gameOver
    public static string stageNum;
    public static string difficulty;
    public static string single_multi;
    public static int quality = 4;
    public static int width = 1280;
    public static int height = 720;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 60;
    }


void Start()
    {
    }

    void Update()
    {
        deltaTimer += Time.deltaTime;

        if (inGame && !isPause)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canPlayerMove = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if(inGame && isPause && single_multi =="single")
                canPlayerMove = false;
        }
    }
}

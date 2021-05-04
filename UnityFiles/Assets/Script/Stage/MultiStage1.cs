using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiStage1 : Photon.PunBehaviour
{
    // 敵の生成はx,zは(-499~+499),yは(1~399)の以内にすることをお勧め。
    [SerializeField] GameObject B_01;
    [SerializeField] GameObject E_01;
    [SerializeField] GameObject E_02;
    private int i;
    private GameObject enemies;

    private float[] GenTime;
    private bool[] GenCount;


    //struct En
    //{
    //    GameObject Object;
    //    Vector3 Pos;
    //    Quaternion Rot;
    //}

    void Start()
    {
        Screen.SetResolution(GameManager.width, GameManager.height, Screen.fullScreen);
        QualitySettings.SetQualityLevel(GameManager.quality, true);
        enemies = GameObject.Find("Enemies");
        GenTime = new float[9999];
        GenCount = new bool[9999];
        for (int num = 0; num<9999; num++)
        {
            GenTime[num] = num;
            GenCount[num] = false;
        }
    }

    void Update()
    {
        if (GameManager.isPause)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameManager.canPlayerMove = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GameManager.canPlayerMove = true;
        }
        Counting();
        Gen();
    }

    private void Gen()
    {
        if (GenCount[15])
        {
            PhotonManagerScript.InstantiateSceneObject(B_01, new Vector3(0, 20, 100), Quaternion.Euler(270, 180, 0)).transform.parent = enemies.transform;
            GenCount[15] = false;
        }
        if (GenCount[10])
        {
            PhotonManagerScript.InstantiateSceneObject(E_02, new Vector3(200, 10, 1000), Quaternion.identity).transform.parent = enemies.transform;
            // Instantiate(E_02, new Vector3(-200, 10, 1000), Quaternion.identity).transform.parent = enemies.transform;
            // Instantiate(E_02, new Vector3(200, 30, 1000), Quaternion.identity).transform.parent = enemies.transform;
            // Instantiate(E_02, new Vector3(-200, 30, 1000), Quaternion.identity).transform.parent = enemies.transform;
            // Instantiate(E_02, new Vector3(200, 50, 1000), Quaternion.identity).transform.parent = enemies.transform;
            // Instantiate(E_02, new Vector3(-200, 50, 1000), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[10] = false;
        }
        if (GenCount[7])
        {
            // Instantiate(E_02, new Vector3(200, 30, 490), Quaternion.identity).transform.parent = enemies.transform;
            // Instantiate(E_02, new Vector3(-200, 30, 490), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[7] = false;
        }
        if (GenCount[5])
        {
            // Instantiate(E_02, new Vector3(200, 50, 490), Quaternion.identity).transform.parent = enemies.transform;
            // Instantiate(E_02, new Vector3(-200, 50, 490), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[5] = false;
        }
        if (GenCount[3])
        {
            // Instantiate(E_02, new Vector3(200, 30, 490), Quaternion.identity).transform.parent = enemies.transform;
            // Instantiate(E_02, new Vector3(-200, 30, 490), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[3] = false;
        }
        if (GenCount[2])
        {
            // Instantiate(E_01, new Vector3(20, 10, 150), Quaternion.identity).transform.parent = enemies.transform;
            // Instantiate(E_01, new Vector3(-20, 10, 150), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[2] = false;
        }
    }

    private void Counting()
    {
        if (Time.timeSinceLevelLoad > GenTime[i])
        {
            GenCount[i] = true;
            i++;
        }
    }
}

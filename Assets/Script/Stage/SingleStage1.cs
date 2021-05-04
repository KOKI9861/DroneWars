using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStage1 : MonoBehaviour
{

    [SerializeField] bool OnlineFlag = false;
    // 敵の生成はx,zは(-499~+499),yは(1~399)の以内にすることをお勧め。
    public GameObject[] Boss;
    public GameObject[] Enemy;
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
        if(!PlayerInformation.OnlineFlag){
            Gen();
        }else{
            Gen_Online();
        }
    }

    private void Gen()
    {
        for(int i=20; i<1000; i += 20) { 
            if (GenCount[i])
            {
                float newY = (250 - (i-20) * 2) % 250;
                while (newY <= 0) newY += 260;
                Instantiate(Enemy[1], new Vector3(-300, 50, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //Instantiate(Enemy[1], new Vector3(-300, 90, 1000), Quaternion.identity).transform.parent = enemies.transform;
                Instantiate(Enemy[1], new Vector3(-300, 130, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //Instantiate(Enemy[1], new Vector3(-300, 170, 1000), Quaternion.identity).transform.parent = enemies.transform;
                Instantiate(Enemy[1], new Vector3(-300, 210, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //Instantiate(Enemy[1], new Vector3(-200, newY, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //Instantiate(Enemy[1], new Vector3(-100, newY, 1000), Quaternion.identity).transform.parent = enemies.transform;
                Instantiate(Enemy[1], new Vector3(0, newY, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //Instantiate(Enemy[1], new Vector3(100, newY, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //Instantiate(Enemy[1], new Vector3(200, newY, 1000), Quaternion.identity).transform.parent = enemies.transform;
                Instantiate(Enemy[1], new Vector3(300, 50, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //Instantiate(Enemy[1], new Vector3(300, 90, 1000), Quaternion.identity).transform.parent = enemies.transform;
                Instantiate(Enemy[1], new Vector3(300, 130, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //Instantiate(Enemy[1], new Vector3(300, 170, 1000), Quaternion.identity).transform.parent = enemies.transform;
                Instantiate(Enemy[1], new Vector3(300, 210, 1000), Quaternion.identity).transform.parent = enemies.transform;
                GenCount[i] = false;
            }
        }
        if (GenCount[15])
        {
            Instantiate(Boss[0], new Vector3(0, 20, 100), Quaternion.Euler(270, 180, 0)).transform.parent = enemies.transform;
            GenCount[15] = false;
        }
        if (GenCount[10])
        {
            Instantiate(Enemy[1], new Vector3(200, 10, 1000), Quaternion.identity).transform.parent = enemies.transform;
            Instantiate(Enemy[1], new Vector3(-200, 10, 1000), Quaternion.identity).transform.parent = enemies.transform;
            Instantiate(Enemy[1], new Vector3(200, 30, 1000), Quaternion.identity).transform.parent = enemies.transform;
            Instantiate(Enemy[1], new Vector3(-200, 30, 1000), Quaternion.identity).transform.parent = enemies.transform;
            Instantiate(Enemy[1], new Vector3(200, 50, 1000), Quaternion.identity).transform.parent = enemies.transform;
            Instantiate(Enemy[1], new Vector3(-200, 50, 1000), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[10] = false;
        }
        if (GenCount[7])
        {
            Instantiate(Enemy[1], new Vector3(200, 30, 490), Quaternion.identity).transform.parent = enemies.transform;
            Instantiate(Enemy[1], new Vector3(-200, 30, 490), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[7] = false;
        }
        if (GenCount[5])
        {
            Instantiate(Enemy[1], new Vector3(200, 50, 490), Quaternion.identity).transform.parent = enemies.transform;
            Instantiate(Enemy[1], new Vector3(-200, 50, 490), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[5] = false;
        }
        if (GenCount[3])
        {
            Instantiate(Enemy[1], new Vector3(200, 30, 490), Quaternion.identity).transform.parent = enemies.transform;
            Instantiate(Enemy[1], new Vector3(-200, 30, 490), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[3] = false;
        }
        if (GenCount[2])
        {
            Instantiate(Enemy[0], new Vector3(20, 10, 150), Quaternion.identity).transform.parent = enemies.transform;
            Instantiate(Enemy[0], new Vector3(-20, 10, 150), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[2] = false;
        }
    }

    private void Gen_Online()
    {
        for (int i = 20; i < 1000; i += 20)
        {
            if (GenCount[i])
            {
                float newY = (250 - (i - 20) * 2) % 250;
                while (newY <= 0) newY += 260;
                PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-300, 50, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-300, 90, 1000), Quaternion.identity).transform.parent = enemies.transform;
                PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-300, 130, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-300, 170, 1000), Quaternion.identity).transform.parent = enemies.transform;
                PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-300, 210, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-200, newY, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-100, newY, 1000), Quaternion.identity).transform.parent = enemies.transform;
                PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(0, newY, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(100, newY, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(200, newY, 1000), Quaternion.identity).transform.parent = enemies.transform;
                PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(300, 50, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(300, 90, 1000), Quaternion.identity).transform.parent = enemies.transform;
                PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(300, 130, 1000), Quaternion.identity).transform.parent = enemies.transform;
                //PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(300, 170, 1000), Quaternion.identity).transform.parent = enemies.transform;
                PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(300, 210, 1000), Quaternion.identity).transform.parent = enemies.transform;
                GenCount[i] = false;
            }
        }
        if (GenCount[15])
        {
            PhotonManagerScript.InstantiateSceneObject(Boss[0], new Vector3(0, 20, 100), Quaternion.Euler(270, 180, 0)).transform.parent = enemies.transform;
            GenCount[15] = false;
        }
        if (GenCount[10])
        {
            PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(200, 10, 1000), Quaternion.identity).transform.parent = enemies.transform;
            PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-200, 10, 1000), Quaternion.identity).transform.parent = enemies.transform;
            PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(200, 30, 1000), Quaternion.identity).transform.parent = enemies.transform;
            PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-200, 30, 1000), Quaternion.identity).transform.parent = enemies.transform;
            PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(200, 50, 1000), Quaternion.identity).transform.parent = enemies.transform;
            PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-200, 50, 1000), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[10] = false;
        }
        if (GenCount[7])
        {
            PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(200, 30, 490), Quaternion.identity).transform.parent = enemies.transform;
            PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-200, 30, 490), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[7] = false;
        }
        if (GenCount[5])
        {
            PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(200, 50, 490), Quaternion.identity).transform.parent = enemies.transform;
            PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-200, 50, 490), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[5] = false;
        }
        if (GenCount[3])
        {
            PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(200, 30, 490), Quaternion.identity).transform.parent = enemies.transform;
            PhotonManagerScript.InstantiateSceneObject(Enemy[1], new Vector3(-200, 30, 490), Quaternion.identity).transform.parent = enemies.transform;
            GenCount[3] = false;
        }
        if (GenCount[2])
        {
            PhotonManagerScript.InstantiateSceneObject(Enemy[0], new Vector3(20, 10, 150), Quaternion.identity).transform.parent = enemies.transform;
            PhotonManagerScript.InstantiateSceneObject(Enemy[0], new Vector3(-20, 10, 150), Quaternion.identity).transform.parent = enemies.transform;
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

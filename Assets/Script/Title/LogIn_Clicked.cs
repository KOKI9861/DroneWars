using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogIn_Clicked : MonoBehaviour
{

    public GameObject ButtonPanel;
    public GameObject LogInPanel;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    //クリックされた時の処理
    public void Clicked()
    {
        ButtonPanel.SetActive(false);
        LogInPanel.SetActive(true);
    }
}

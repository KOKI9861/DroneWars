using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer_Back : MonoBehaviour
{

    public GameObject ButtonPanel;
    public GameObject LogInSignUpPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        ButtonPanel.SetActive(true);
        LogInSignUpPanel.SetActive(false);
    }
}

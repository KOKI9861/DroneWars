using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignUp_Clicked : MonoBehaviour
{


    public GameObject ButtonPanel;
    public GameObject SignUpPanel;
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
        ButtonPanel.SetActive(false);
        SignUpPanel.SetActive(true);
    }
}

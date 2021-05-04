using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AccountSetting : MonoBehaviour
{
    public Button ChangeUserNameBtn;
    public Button ChangePasswordBtn;
    public Button DeleteScoreBtn;
    public Button DeleteAccountBtn;


    public GameObject ChangeUserNamePanel;
    public GameObject ChangePasswordPanel;
    public GameObject DeleteScorePanel;
    public GameObject DeleteAccountPanel;


    // Start is called before the first frame update
    void Start()
    {
        ChangeUserNameBtn.onClick.AddListener(ClickChangeUserName);
        ChangePasswordBtn.onClick.AddListener(ClickChangePassword);
        DeleteScoreBtn.onClick.AddListener(ClickDeleteScore);
        DeleteAccountBtn.onClick.AddListener(ClickDeleteAccount);

        ChangeUserNamePanel.SetActive(false);
        ChangePasswordPanel.SetActive(false);
        DeleteScorePanel.SetActive(false);
        DeleteAccountPanel.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickChangeUserName(){
        ChangeUserNamePanel.SetActive(true);
    }

    void ClickChangePassword(){
        ChangePasswordPanel.SetActive(true);
    }

    void ClickDeleteScore(){
        DeleteScorePanel.SetActive(true);
    }

    void ClickDeleteAccount(){
        DeleteAccountPanel.SetActive(true);

    }
}

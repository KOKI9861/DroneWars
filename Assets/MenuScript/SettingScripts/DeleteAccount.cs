using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DeleteAccount : MonoBehaviour
{
    public GameObject thisPanel;
    public static Text Message;
    public Button OKBtn;
    public Button CancelBtn;

    // Start is called before the first frame update
    void Start()
    {
        Message = transform.Find("Message").GetComponent<Text>();
        Message.text = "このアカウントを削除してもよろしいですか?";

        OKBtn.onClick.AddListener(ClickOK);
        CancelBtn.onClick.AddListener(ClickCancel);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickOK(){
        NCMBManagerScript.deleteAccount();
    }

    void ClickCancel(){
        thisPanel.SetActive(false);
        Message.text = "このアカウントを削除してもよろしいですか?";
    }

    public static void setMessage(string message){
        Message.text = message;
    }
}

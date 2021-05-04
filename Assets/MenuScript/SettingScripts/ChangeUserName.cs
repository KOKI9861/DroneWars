using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class ChangeUserName : MonoBehaviour
{
    public GameObject thisPanel;
    public Text NowUserName;
    public InputField NewUserName;
    public Button OKBtn;
    public Button ReturnBtn;

    public static Text Message;


    // Start is called before the first frame update
    void Start()
    {
        Message = transform.Find("Message").GetComponent<Text>();
        Message.text = "変更したいユーザー名を入力してください";

        OKBtn.onClick.AddListener(ClickOK);
        ReturnBtn.onClick.AddListener(ClickReturn);

        NowUserName.text = "あなたのユーザー名\n"+NCMBUser.CurrentUser.UserName;
    }

    // Update is called once per frame
    void Update()
    {
        NowUserName.text = "あなたのユーザー名\n"+NCMBUser.CurrentUser.UserName;
        
    }

    void ClickOK(){
        if(NewUserName.text == ""){
            Message.text = "入力してください";
            return;
        }
        NCMBManagerScript.changeName(NewUserName.text);

        NewUserName.text = "";
    }

    void ClickReturn(){
        thisPanel.SetActive(false);
        Message.text = "変更したいユーザー名を入力してください";
    }

    public static void setMessage(string message){
        Message.text = message;
    }
}

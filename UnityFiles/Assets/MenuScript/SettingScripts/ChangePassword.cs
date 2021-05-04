using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangePassword : MonoBehaviour
{
    public GameObject thisPanel;
    public InputField NowPassword;
    public InputField NewPassword1;
    public InputField NewPassword2;

    public Button OKBtn;
    public Button ReturnBtn;

    public static Text Message;


    // Start is called before the first frame update
    void Start()
    {
        Message = transform.Find("Message").GetComponent<Text>();
        Message.text = "現在のパスワードと新しいパスワードを入力してください";

        OKBtn.onClick.AddListener(ClickOK);
        ReturnBtn.onClick.AddListener(ClickReturn);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickOK(){
        if(NowPassword.text == "" || NewPassword1.text == "" || NewPassword2.text == ""){
            Message.text = "入力してください";
            return;
        }
        if(NowPassword.text != PlayerInformation.password){
            Message.text = "現在のパスワードが違います";
            return;
        }
        if(NewPassword1.text != NewPassword2.text){
            Message.text = "新しいパスワードが一致しません";
            return;
        }

        // NCMBManagerScript.changePassword(NewPassword1.text);

        NowPassword.text = "";
        NewPassword1.text = "";
        NewPassword2.text = "";
    }

    void ClickReturn(){
        thisPanel.SetActive(false);
        Message.text = "現在のパスワードと新しいパスワードを入力してください";
        
    }

    public static void setMessage(string message){
        Message.text = message;
    }
}

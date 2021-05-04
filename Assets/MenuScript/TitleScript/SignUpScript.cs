using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class SignUpScript : MonoBehaviour
{
    // public GameObject NCMBManager;
    // private NCMBManagerScript ncmb;

    public GameObject ButtonPanel;
    public GameObject SignUpPanel;
    public TMP_InputField NameInputField;
    public TMP_InputField PasswordInputField;
    public TMP_InputField PasswordInputField2;
    public TextMeshProUGUI VisiblePassword;
    public TextMeshProUGUI VisiblePassword2;
    public Button EyeBtn;
    public Button EyeBtn2;
    public Button SignUpBtn;

    public Button ReturnBtn;
    public static Text Message;

    private Vector3 returnBtnScale;

    // Start is called before the first frame update
    void Start()
    {
        Message = transform.Find("Message").GetComponent<Text>();

        returnBtnScale = ReturnBtn.transform.localScale;
        // SignUpBtn.onClick.AddListener(ClickSignUp);
        // ReturnBtn.onClick.AddListener(ClickReturn);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.Return)) {
            ClickSignUp();
        }
    }


    public void EyeDown(){
        VisiblePassword.text = PasswordInputField.text;
        PasswordInputField.text = null;
    }

    public void EyeUp(){
        PasswordInputField.text = VisiblePassword.text;
        VisiblePassword.text = null;
    }
    
    public void EyeDown2(){
        VisiblePassword2.text = PasswordInputField2.text;
        PasswordInputField2.text = null;
    }

    public void EyeUp2(){
        PasswordInputField2.text = VisiblePassword2.text;
        VisiblePassword2.text = null;
    }

    public void ClickSignUp(){
        if(PasswordInputField.text != PasswordInputField2.text){
            Message.text = "パスワードが一致しません";
            return;
        }

        NCMBManagerScript.signUp(NameInputField.text,PasswordInputField.text);
        
    }

    public void ClickReturn(){
        SignUpPanel.SetActive(false);

        //アニメーションで大きさがずれるっぽいので初期化
        ButtonPanel.transform.Find("LogInButton").transform.localScale = TitleManager.btnScale;
        ButtonPanel.transform.Find("SignUpButton").transform.localScale = TitleManager.btnScale;
        ButtonPanel.SetActive(true);

        ReturnBtn.transform.localScale = returnBtnScale;
    }

    public static void setMessage(string message){
        Message.text = message;
    }

}

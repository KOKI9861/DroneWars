using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class LogInScript : MonoBehaviour
{
    public GameObject ButtonPanel;
    public GameObject LogInPanel;
    public TMP_InputField NameInputField;
    public TMP_InputField PasswordInputField;
    public TextMeshProUGUI VisiblePassword;
    private string password;
    public Button EyeBtn;

    public Toggle saveNamePass;
    public Button LogInBtn;

    public Button ReturnBtn;
    public static Text Message;

    private Vector3 returnBtnScale;

    // Start is called before the first frame update
    void Start()
    {
        Message = transform.Find("Message").GetComponent<Text>();

        returnBtnScale = ReturnBtn.transform.localScale;

        // ボタンの設定
        // LogInBtn.GetComponent<Button>().onClick.AddListener(ClickLogIn);
        // ReturnBtn.GetComponent<Button>().onClick.AddListener(ClickReturn);

        if(PlayerPrefs.HasKey("PlayerName") && PlayerPrefs.HasKey("Password")){
            NameInputField.text = PlayerPrefs.GetString("PlayerName");
            PasswordInputField.text = PlayerPrefs.GetString("Password");
        }
        if(PlayerPrefs.HasKey("saveOn")){
            if(PlayerPrefs.GetInt("saveOn") == 1){
                saveNamePass.isOn = true;
            }else{
                saveNamePass.isOn = false;
            }
        }
        Debug.Log(NameInputField.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.Return)) {
            ClickLogIn();
        }
    }

    // パスワード入力の表示ボタン
    // クリックしているときのみパスワード表示
    public void EyeDown(){
        VisiblePassword.text = PasswordInputField.text;
        PasswordInputField.text = null;
        

    }

    public void EyeUp(){
        PasswordInputField.text = VisiblePassword.text;
        VisiblePassword.text = null;
        
        
    }

    public void ClickLogIn(){
        NCMBManagerScript.logIn(NameInputField.text,PasswordInputField.text);
        
        if(saveNamePass.isOn){
            PlayerPrefs.SetString("PlayerName",NameInputField.text);
            PlayerPrefs.SetString("Password",PasswordInputField.text);
            PlayerPrefs.SetInt("saveOn",1);
        }else{
            PlayerPrefs.SetString("PlayerName",null);
            PlayerPrefs.SetString("Password",null);
            PlayerPrefs.SetInt("saveOn",0);
        }
    }

    public void ClickReturn(){
        LogInPanel.SetActive(false);

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

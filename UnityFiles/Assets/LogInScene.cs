using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogInScene : MonoBehaviour
{
    public GameObject LogInPanel;
    public InputField NameInputField;
    public InputField PasswordInputField;

    public Text VisiblePassword;
    public Button EyeBtn;

    public Toggle saveNamePass;

    public Button go;
    public Button back;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName") && PlayerPrefs.HasKey("Password"))
        {
            NameInputField.text = PlayerPrefs.GetString("PlayerName");
            PasswordInputField.text = PlayerPrefs.GetString("Password");
        }
        if (PlayerPrefs.HasKey("saveOn"))
        {
            if (PlayerPrefs.GetInt("saveOn") == 1)
            {
                saveNamePass.isOn = true;
            }
            else
            {
                saveNamePass.isOn = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Clicked();
        }
    }

    public void EyeDown()
    {
        VisiblePassword.text = PasswordInputField.text;
        PasswordInputField.text = null;
    }


    public void EyeUp()
    {
        PasswordInputField.text = VisiblePassword.text;
        VisiblePassword.text = null;
    }

    public void Clicked()
    {
        NCMBManagerScript.logIn(NameInputField.text, PasswordInputField.text);

        if (saveNamePass.isOn)
        {
            PlayerPrefs.SetString("PlayerName", NameInputField.text);
            PlayerPrefs.SetString("Password", PasswordInputField.text);
            PlayerPrefs.SetInt("saveOn", 1);
        }
        else
        {
            PlayerPrefs.SetString("PlayerName", null);
            PlayerPrefs.SetString("Password", null);
            PlayerPrefs.SetInt("saveOn", 0);
        }

        SceneManager.LoadScene("TopPage");
    }
}
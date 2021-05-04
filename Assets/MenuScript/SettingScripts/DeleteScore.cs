using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeleteScore : MonoBehaviour
{
    public GameObject thisPanel;
    public static Text Message;
    public Button OKBtn;
    public Button CancelBtn;

    // Start is called before the first frame update
    void Start()
    {
        Message = transform.Find("Message").GetComponent<Text>();
        Message.text = "スコアをリセットしてもよろしいですか?";

        OKBtn.onClick.AddListener(ClickOK);
        CancelBtn.onClick.AddListener(ClickCancel);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickOK(){
        for(int i=0;i<PlayerInformation.highScore.Length;i++){
            PlayerInformation.highScore[i] = 0;
        }
        NCMBManagerScript.saveData();

        Message.text = "スコアをリセットしました";

        
    }

    void ClickCancel(){
        thisPanel.SetActive(false);
        Message.text = "スコアをリセットしてもよろしいですか?";
    }

    public static void setMessage(string message){
        Message.text = message;
    }
}

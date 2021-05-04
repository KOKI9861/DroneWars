using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaveScoreScript : MonoBehaviour
{
    public GameObject RecordPanel;
    public InputField scoreField;
    public Button saveBtn;
    public Button ReturnBtn;
    public Text MyScore;

    // Start is called before the first frame update
    void Start()
    {
        saveBtn.onClick.AddListener(ClickSave);
        ReturnBtn.onClick.AddListener(ClickReturn);

        //スコア表示　仮にMultiの難易度をExpertにしているのでOnlineのところを[4]としている
        MyScore.text = "ONLINE:"+PlayerInformation.highScore[4]+" EASY:"+PlayerInformation.highScore[1]+
                        " NORMAL:"+PlayerInformation.highScore[2]+" HARD:"+PlayerInformation.highScore[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickSave(){
        if(scoreField.text == null){
            return;
        }

        int NewScore = int.Parse(scoreField.text);

        PlayerInformation.saveHighScore("easy",NewScore);

        MyScore.text = "ONLINE:"+PlayerInformation.highScore[4]+" EASY:"+PlayerInformation.highScore[1]+
                        " NORMAL:"+PlayerInformation.highScore[2]+" HARD:"+PlayerInformation.highScore[3];
        
    }

    void ClickReturn(){
        RecordPanel.SetActive(false);
    }
}

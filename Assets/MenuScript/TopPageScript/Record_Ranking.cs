using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Record_Ranking : MonoBehaviour
{
    public GameObject thisPanel;
    public Button EnterBtn;
    public Text myScore;
    public Text OnlineRanking;
    public Text EasyRanking;
    public Text NormalRanking;
    public Text HardRanking;


    public Button ReturnBtn;

    // Start is called before the first frame update
    void Start()
    {
        ReturnBtn.onClick.AddListener(ClickReturn);
        EnterBtn.onClick.AddListener(ClickEnter);

        myScore.text = "ONLINE:"+PlayerInformation.highScore[4]+" EASY:"+PlayerInformation.highScore[1]+
                        " NORMAL:"+PlayerInformation.highScore[2]+" HARD:"+PlayerInformation.highScore[3];

        writeRanking();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickEnter(){
        myScore.text = "ONLINE:"+PlayerInformation.highScore[4]+" EASY:"+PlayerInformation.highScore[1]+
                        " NORMAL:"+PlayerInformation.highScore[2]+" HARD:"+PlayerInformation.highScore[3];

        writeRanking();
    }

    void ClickReturn(){
        thisPanel.SetActive(false);
    }

    void writeRanking(){
        OnlineRanking.text = "<b><size=22>  ONLINE TOP10</size></b>\n";
        NCMBManagerScript.getRanking("expert",OnlineRanking);

        EasyRanking.text = "<b><size=22>  EASY TOP10</size></b>\n";
        NCMBManagerScript.getRanking("easy",EasyRanking);

        NormalRanking.text = "<b><size=22>  NORMAL TOP10</size></b>\n";
        NCMBManagerScript.getRanking("normal",NormalRanking);

        HardRanking.text = "<b><size=22>  HARD TOP10</size></b>\n";
        NCMBManagerScript.getRanking("hard",HardRanking);
    }
}

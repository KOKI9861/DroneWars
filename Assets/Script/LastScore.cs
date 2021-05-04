using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LastScore : MonoBehaviour
{
    private float score;
    private float tmpScore;
    private float upValue = 30000f;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("ScorePanel").GetComponent<Score>().score;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score);
        //if (tmpScore < score)
        //{
        //    GetComponent<Text>().text = "スコア : " + (int)tmpScore + "pt";
        //    tmpScore += (upValue * Time.deltaTime);
        //}
        //else
        //    GetComponent<Text>().text = "スコア : " + score + "pt";

        score = GameObject.Find("ScorePanel").GetComponent<Score>().score;
        GetComponent<Text>().text = "スコア : " + score + "pt";
        if(PlayerInformation.saveHighScore(GameManager.difficulty,(int)score)){//スコアを保存,ハイスコアだったら
            GetComponent<Text>().text += "/nハイスコア更新！！";
        }
    }

}

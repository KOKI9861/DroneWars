
/*　ここにはプレイヤー情報を格納しておく
名前：playerName
パスワード：password
ランク：rank
ハイスコア：highScore[]
選択している難易度：

 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public static string playerName;
    //名前
    //ログイン時に代入
    public static string password;
    //パスワード
    //ログイン時に代入

    public static bool OnlineFlag = false;
    //オンライン対戦かどうかを判定
    //Trueならオンライン対戦

    public static int rank;
    //ランク

    public static int[] highScore = {0,0,0,0,0};
    //ハイスコア　[0]:ONLINE [1]:EASY [2]:NORMAL [3]:HARD [4]:EXPERT
    //新規登録時は全て0に設定
    //ログイン時はNCMBサーバからハイスコアを受け取る


    //名前とパスワードを保持
    //ログイン時
    public static void setNamePass(string name,string pass){
        playerName = name;
        password = pass;
    }

    //ハイスコアを保存する
    //levelにはonline,easy,nomal,hard,expertのどれか
    //NewScoreに今のスコアを
    //ハイスコアだったらサーバのデータを更新するようにしてある
    public static bool saveHighScore(string level,int NewScore){
        int levelNum = 0;

        if(level == "online"){
            levelNum = 0;
        }else if(level == "easy"){
            levelNum = 1;
        }else if(level == "normal"){
            levelNum = 2;
        }else if(level == "hard"){
            levelNum = 3;
        }else if(level == "expert"){
            levelNum = 4;
        }

        if(NewScore > highScore[levelNum]){
            highScore[levelNum] = NewScore;
            NCMBManagerScript.saveData();
            return true;
        }else{
            Debug.Log(NewScore+"はハイスコアではありません。現在の"+level+"のハイスコアは"+highScore[levelNum]);
            return false;
        }
        return false;
    }

    //プレイヤー情報のリセット
    //ログアウト時に使用
    public static void resetInformation(){
        playerName = "nanashi";
        password = "password";
        OnlineFlag = false;
        rank = 0;
        for(int i=0;i<highScore.Length;i++){
            highScore[i] = 0;
        }
    }


    
}

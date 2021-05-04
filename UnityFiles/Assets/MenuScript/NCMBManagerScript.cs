using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NCMB;

public class NCMBManagerScript : MonoBehaviour
{
    public static string userName = "nanashi";
    public static bool LogInNow = false;
    public static int HighScore;
    public static bool successConnect;


    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 現在のプレイヤー名を返す
    public static string getUserName()
    {
        return userName;
    }

    public static int getHighScore()
    {
        return HighScore;
    }

    public static bool getSuccessConnect()
    {
        return successConnect;
    }

    // ログイン機能
    public static void logIn(string name, string password)
    {
        LogInScript.setMessage("サーバーに接続しています");
        userName = name;
        
        // これがどうもうまくいかない
        // 非同期処理だから処理終了を待たずに進んじゃう
        // 処理終了を待つwaitの使い方もよくわからない
        // LogInOrNot();
        // if(LogInNow){
        //     Debug.Log("二重ログインだよ");
        //     return;
        // }
        //////

        NCMBUser.LogInAsync(name, password, (NCMBException e) =>
        {
            //接続成功したら
            if (e == null)
            {
                // getData("test");
                getData();

                successConnect = true;
                LogInNow = true;
                // saveLogInNow();
                
                LogInScript.setMessage("ログインしました");
                // Debug.Log("ログインしたよ"+userName+":"+HighScore);
                PlayerInformation.setNamePass(name,password);
                PhotonNetwork.playerName = name;
                Debug.Log(PhotonNetwork.player.NickName); //playerの名前を確認
                SceneManager.LoadScene("TopPage");
                return;
            }
            else if (e.ErrorCode == NCMBException.REQUIRED || e.ErrorCode == NCMBException.RELATION_ERROR)
            {
                LogInScript.setMessage("入力が不十分です");
                Debug.Log("未入力です");
            }
            else if (e.ErrorCode == NCMBException.INCORRECT_PASSWORD)
            {
                LogInScript.setMessage("ユーザー名またはパスワードが間違っています");
                Debug.Log("ユーザー名またはパスワードが間違っています");
            }
            else if (e.ErrorCode == "408")
            {
                LogInScript.setMessage("サーバーとの接続が切断されました");
                Debug.Log("タイムアウト");
            }
            else
            {
                successConnect = false;
                LogInScript.setMessage(e.ErrorCode + ":" + e.Message);                
                Debug.Log(e.ErrorCode + ":" + e.Message);
                return;
            }
        });


    }

    // 新規登録
    public static void signUp(string name, string password)
    {

        SignUpScript.setMessage("サーバーに接続しています");

        NCMBUser user = new NCMBUser();
        user.UserName = name;
        user.Password = password;
        user.SignUpAsync((NCMBException e) =>
        {
            // 接続成功したら
            if (e == null)
            {
                successConnect = true;
                userName = name;
                // getData("test");
                saveData();
                LogInNow = true;
                // saveLogInNow();

                SignUpScript.setMessage("登録しました");
                Debug.Log("登録したよ");
                PlayerInformation.setNamePass(name,password);
                PhotonNetwork.playerName = name;
                Debug.Log(PhotonNetwork.player.NickName); //playerの名前を確認
                SceneManager.LoadScene("TopPage");
                return;
            }
            else if (e.ErrorCode == NCMBException.REQUIRED || e.ErrorCode == NCMBException.RELATION_ERROR)
            {
                SignUpScript.setMessage("入力が不十分です");
                Debug.Log("未入力です");
            }
            else if (e.ErrorCode == NCMBException.DUPPLICATION_ERROR)
            {
                SignUpScript.setMessage("そのユーザー名は既に使われています");
                Debug.Log("そのユーザー名は既に使われています");
            }
            else if (e.ErrorCode == "408")
            {
                SignUpScript.setMessage("サーバーとの接続が切断されました");
                Debug.Log("タイムアウト");
            }
            else
            {
                SignUpScript.setMessage(e.ErrorCode + ":" + e.Message);
                successConnect = false;
                Debug.Log(e.ErrorCode + ":" + e.Message);
                return;
            }
        });

    }

    // ログアウト
    public static void logOut()
    {
        NCMBUser.LogOutAsync((NCMBException e) =>
        {
            // 接続成功したら
            if (e == null)
            {
                LogInNow = false;
                // saveLogInNow();

                userName = "nanashi";
                successConnect = true;
                Debug.Log("ログアウトしたよ");
                PlayerInformation.resetInformation();
                PhotonNetwork.playerName = userName;
                Debug.Log(PhotonNetwork.player.NickName); //playerの名前を確認
                SceneManager.LoadScene("Title");
                return;
            }
            else
            {
                successConnect = false;
                Debug.Log(e.ErrorCode + ":" + e.Message);
                return;
            }


        });

    }


    //ユーザアカウントの削除
    public static void deleteAccount(){
        
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("user");
        query.WhereEqualTo("userName", PlayerInformation.playerName);
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {

            //検索成功したら
            if (e == null)
            {
                objList[0].DeleteAsync((NCMBException ne) =>
                {
                    if(ne==null)
                    {
                        deleteData("HighScore");
                        LogInNow = false;
                        // saveLogInNow();

                        userName = "nanashi";
                        successConnect = true;
                        DeleteAccount.setMessage("削除しました");
                        Debug.Log("アカウントを削除したよ");
                        PlayerInformation.resetInformation();
                        PhotonNetwork.playerName = userName;
                        Debug.Log(PhotonNetwork.player.NickName); //playerの名前を確認
                        SceneManager.LoadScene("Title");
                        return;
                    }
                    else
                    {
                        DeleteAccount.setMessage("エラー"+e.ErrorCode + ":" + e.Message);
                    }
                });
            }

        });
    }

    public static void deleteData(string key){
        // データストアの「key」クラスから、Nameをキーにして検索
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(key);
        query.WhereEqualTo("userName", PlayerInformation.playerName);
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {

            //検索成功したら
            if (e == null)
            {
                objList[0].DeleteAsync();
                Debug.Log(key+"を削除しました");

            }
            else
            {
                Debug.Log(e.ErrorCode + ":" + e.Message);
            }

        });
    }

    // 二重ログインがされないように書いたけど
    // 非同期処理だからかうまく働かない
    // public static void LogInOrNot(){

    //     // データストアの「LogInNow」クラスから、Nameをキーにして検索
    //     NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("LogInNow");
    //     query.WhereEqualTo("userName", getUserName());
    //     query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
    //     {

    //         //検索成功したら
    //         if (e == null)
    //         {
    //             // LogInNowが未登録だったら
    //             if (objList.Count == 0)
    //             {
    //                 NCMBObject obj = new NCMBObject("LogInNow");
    //                 obj["userName"] = getUserName();
    //                 obj["LogInNow"] = true;
    //                 obj.SaveAsync();
    //                 LogInNow = false;
                    
    //             }
    //             // LogInNowが登録済みだったら
    //             else
    //             {
    //                 LogInNow = System.Convert.ToBoolean(objList[0]["LogInNow"]);
                    
    //             }

    //         }

    //     });
    // }


    // public static void saveLogInNow()
    // {
    //     NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("LogInNow");

    //     query.WhereEqualTo ("userName", getUserName());
    //     query.FindAsync ((List<NCMBObject> userList ,NCMBException e) => {

    //         //検索成功したら
    //         if (e == null) {
    //             userList[0]["LogInNow"] = LogInNow;
    //             userList[0].SaveAsync();
    //         }
    //     });
    // }


    // スコア保存
    // PLayerInformationにあるHighScoreを保存
    public static void saveData()
    {
        // データストアの「HighScore」クラスから、Nameをキーにして検索
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("HighScore");
        query.WhereEqualTo("userName", getUserName());
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {

            //検索成功したら
            if (e == null)
            {
                // ハイスコアが未登録だったら
                if (objList.Count == 0)
                {
                    NCMBObject obj = new NCMBObject("HighScore");
                    obj["userName"] = getUserName();
                    // obj[key] = 0;
                    obj["online"] = PlayerInformation.highScore[0];
                    obj["easy"] = PlayerInformation.highScore[1];
                    obj["normal"] = PlayerInformation.highScore[2];
                    obj["hard"] = PlayerInformation.highScore[3];
                    obj["expert"] = PlayerInformation.highScore[4];
                    obj.SaveAsync();
                    
                }
                // ハイスコアが登録済みだったら
                else
                {
                    
                    objList[0]["online"] = PlayerInformation.highScore[0];
                    objList[0]["easy"] = PlayerInformation.highScore[1];
                    objList[0]["normal"] = PlayerInformation.highScore[2];
                    objList[0]["hard"] = PlayerInformation.highScore[3];
                    objList[0]["expert"] = PlayerInformation.highScore[4];
                    
                    objList[0].SaveAsync();
                }

            }

        });

    }

    // サーバーからハイスコアを取得  -----------------
    // key ：online easy nomal hard expertとかを入力    
    public static void getData()
    {
        // int score = 0;
        
        // データストアの「HighScore」クラスから、Nameをキーにして検索
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("HighScore");
        query.WhereEqualTo("userName", getUserName());
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {

            //検索成功したら
            if (e == null)
            {
                // ハイスコアが未登録だったら
                if (objList.Count == 0)
                {
                    saveData();
                }
                // ハイスコアが登録済みだったら
                else
                {
                    PlayerInformation.highScore[0] = System.Convert.ToInt32(objList[0]["online"]);
                    PlayerInformation.highScore[1] = System.Convert.ToInt32(objList[0]["easy"]);
                    PlayerInformation.highScore[2] = System.Convert.ToInt32(objList[0]["normal"]);
                    PlayerInformation.highScore[3] = System.Convert.ToInt32(objList[0]["hard"]);
                    PlayerInformation.highScore[4] = System.Convert.ToInt32(objList[0]["expert"]);
                    
                    // score = System.Convert.ToInt32(objList[0][key]);
                    // Debug.Log(key+"今までのハイスコア："+score);
                }

            }

            // HighScore = score;
        });
        

    }


    


    // sleepみたいなやつ
    // 非同期処理何とかしようと書いたけど使ってない
    static async void Delay(int ms)
    {
        await Task.Delay(ms);
        
    }



    //ランキング
    //引数levelは online easy normal hard expertのどれか
    public static void getRanking(string level,Text text){

        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");
        query.OrderByDescending (level);   //Scoreを降順で並べ替え
        query.AddAscendingOrder("userName");

        query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {

            //検索成功したら
            if (e == null) {
                Debug.Log(objList.Count);
                for(int i=0;i<objList.Count && i<10;i++){
                    if(userName == System.Convert.ToString(objList[i]["userName"])){
                        text.text += "<b><color=red>";
                    }
                    text.text += (i+1)+". "+System.Convert.ToString(objList[i]["userName"]);
                    text.text += " : "+System.Convert.ToString(objList[i][level])+"\n";
                    if(userName == System.Convert.ToString(objList[i]["userName"])){
                        text.text += "</color></b>";
                    }
                }
                for(int i=objList.Count;i<10;i++){
                    text.text += (i+1)+". Unkown\n";
                }
                
            }else{
                Debug.Log("エラー"+e.ErrorCode + ":" + e.Message);            
            }

        });

        
    }


    //ユーザ名変更
    public static void changeName(string newName){

        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("user");
        query.WhereEqualTo("userName", getUserName());
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {

            //検索成功したら
            if (e == null)
            {
                //HighScoreのほうの名前も変える
                NCMBQuery<NCMBObject> query2 = new NCMBQuery<NCMBObject>("HighScore");
                query2.WhereEqualTo("userName", getUserName());
                query2.FindAsync((List<NCMBObject> objList2, NCMBException e2) =>
                {
                    if (e2 == null)
                    {
                        objList2[0]["userName"] = newName;
                        objList2[0].SaveAsync();

                    }

                });
                
                
                objList[0]["userName"] = newName;

                objList[0].SaveAsync((NCMBException se)=>
                {
                    if(e==null){
                        NCMBUser.LogInAsync(newName,PlayerInformation.password);
                    }
                });

                userName = newName;
                PlayerInformation.setNamePass(newName,PlayerInformation.password);
                PhotonNetwork.playerName = newName;

                ChangeUserName.setMessage("変更しました");



            }
            else
            {
                ChangeUserName.setMessage("エラー"+e.ErrorCode + ":" + e.Message);
                return;
            }

        });

    }


    //パスワード変更
    // public static void changePassword(string newPassword){

    //     NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("user");
    //     query.WhereEqualTo("userName", getUserName());
    //     query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
    //     {

    //         //検索成功したら
    //         if (e == null)
    //         {
                           
                
    //             objList[0]["password"] = newPassword;

    //             objList[0].SaveAsync((NCMBException se)=>
    //             {
    //                 if(e==null){
    //                     NCMBUser.LogInAsync(PlayerInformation.playerName,newPassword);
    //                 }
    //             });

                
    //             PlayerInformation.setNamePass(PlayerInformation.playerName,newPassword);
    //             // PhotonNetwork.playerName = newName;
                                
    //             ChangePassword.setMessage("変更しました");



    //         }
    //         else
    //         {
    //             ChangePassword.setMessage("エラー"+e.ErrorCode + ":" + e.Message);
    //             return;
    //         }

    //     });

    // }
    

    

}

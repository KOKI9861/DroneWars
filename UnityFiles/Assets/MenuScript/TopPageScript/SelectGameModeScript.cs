using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectGameModeScript : MonoBehaviour
{
    public GameObject SelectGameModePanel;
    public Button EASYBtn;
    public Button NORMALBtn;
    public Button HARDBtn;
    public Button ReturnBtn;

    // Start is called before the first frame update
    void Start()
    {
        EASYBtn.onClick.AddListener(ClickEASY);
        NORMALBtn.onClick.AddListener(ClickNORMAL);
        HARDBtn.onClick.AddListener(ClickHARD);
        ReturnBtn.onClick.AddListener(ClickReturn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickEASY(){
        SceneManager.LoadScene("Opening");
        GameManager.isPause = false;
        GameManager.stageNum = "1";
        GameManager.difficulty = "easy";
        GameManager.single_multi = "single";

    }

    void ClickNORMAL(){
        SceneManager.LoadScene("Opening");
        GameManager.isPause = false;
        GameManager.stageNum = "1";
        GameManager.difficulty = "normal";
        GameManager.single_multi = "single";

    }

    void ClickHARD(){
        SceneManager.LoadScene("Opening");
        GameManager.isPause = false;
        GameManager.stageNum = "1";
        GameManager.difficulty = "hard";
        GameManager.single_multi = "single";

    }

    void ClickReturn(){
        SelectGameModePanel.SetActive(false);
    }
}

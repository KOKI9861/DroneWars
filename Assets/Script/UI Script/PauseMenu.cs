using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _MenuPanel;
    [SerializeField] private GameObject _StatusPanel;
    [SerializeField] private string titleScene;    //TopPage
    [SerializeField] private string nextScene;    // NextScene

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.gameEnd==0 && GameManager.inGame)
        {
            if (!GameManager.isPause)
                CallMenu();
            else
                CloseMenu();

            if (_StatusPanel.activeInHierarchy == false)
            {
                _StatusPanel.SetActive(true);
            }
        }
    }
    private void CallMenu()
    {
        if(GameManager.single_multi == "single")
            Time.timeScale = 0f;

        GameManager.isPause = true;
        _MenuPanel.SetActive(true);
        Cursor.visible = true;
    }

    private void CloseMenu()
    {
        if (GameManager.single_multi == "single")
            Time.timeScale = 1f;
        GameManager.isPause = false;
        _MenuPanel.SetActive(false);
        Cursor.visible = false;
    }

    public void ClickContinue()
    {
        if (GameManager.single_multi == "single")
            Time.timeScale = 1f;
        GameManager.isPause = false;
        _MenuPanel.SetActive(false);
        Cursor.visible = false;
    }
    public void ClickDisableUi()
    {
        if (GameManager.single_multi == "single")
            Time.timeScale = 0f;
        GameManager.isPause = false;
        _MenuPanel.SetActive(false);
        _StatusPanel.SetActive(false);
        Cursor.visible = true;
    }
    public void ClickTitle()
    {
        Time.timeScale = 1f;
        GameManager.gameEnd = 0;
        GameManager.inGame = false;
        SceneManager.LoadScene(titleScene);
    }
    public void ClickClear()
    {
        Time.timeScale = 1f;
        GameManager.gameEnd = 0;
        GameManager.inGame = false;
        SceneManager.LoadScene(nextScene);
    }

    public void ClickExit()
    {
        Debug.Log("ClickExit()");
        Application.Quit();
    }

}
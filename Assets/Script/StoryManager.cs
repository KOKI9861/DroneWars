using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{

    private float timer;
    public float sceneTimer = 7.5f;
    public string nextSceneName = "SingleStage1";


    void Start()
    {
        Screen.SetResolution(GameManager.width, GameManager.height, Screen.fullScreen);
        QualitySettings.SetQualityLevel(GameManager.quality, true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) || timer > sceneTimer)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Resolution : MonoBehaviour
{
    private string quality;
    private string resolution;
    private float timer;
    void Awake()
    {
    

    }
    void Start()
    {
        quality = "Quality_" + QualitySettings.GetQualityLevel();
        GameObject.Find(quality).GetComponent<Toggle>().isOn = true;
        resolution = Screen.currentResolution.width + "_" + Screen.currentResolution.height;
        GameObject.Find(resolution).GetComponent<Toggle>().isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!(timer == -1f))
            timer += Time.deltaTime;
        if(timer > 0.3f)
        {
            timer = -1f;
            quality = "Quality_" + QualitySettings.GetQualityLevel();
            GameObject.Find(quality).GetComponent<Toggle>().isOn = true;
            //resolution = Screen.currentResolution.width + "_" + Screen.currentResolution.height;
            resolution = GameManager.width + "_" + GameManager.height;
            GameObject.Find(resolution).GetComponent<Toggle>().isOn = true;
            Debug.Log("Set Comp, " + GameObject.Find(quality).GetComponent<Toggle>() + " " + GameObject.Find(resolution).GetComponent<Toggle>());
        }
    }

    public void FullScreenCheckBox()
    {
        if(Screen.fullScreen != GameObject.Find("FullScreen").GetComponent<Toggle>().isOn)
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void SetResolution()
    {
        if (GameObject.Find("640_360").GetComponent<Toggle>().isOn) { GameManager.width = 640; GameManager.height = 360; }
        if (GameObject.Find("960_540").GetComponent<Toggle>().isOn) { GameManager.width = 960; GameManager.height = 540; }
        if (GameObject.Find("1280_720").GetComponent<Toggle>().isOn) { GameManager.width = 1280; GameManager.height = 720; }
        if (GameObject.Find("1600_900").GetComponent<Toggle>().isOn) { GameManager.width = 1600; GameManager.height = 900; }
        if (GameObject.Find("1920_1080").GetComponent<Toggle>().isOn) { GameManager.width = 1920; GameManager.height = 1080; }
        Screen.SetResolution(GameManager.width, GameManager.height, Screen.fullScreen);
    }
    public void SetQuality()
    {
        if (GameObject.Find("Very Low").GetComponent<Toggle>().isOn) GameManager.quality = 0;
        if (GameObject.Find("Low").GetComponent<Toggle>().isOn) GameManager.quality = 1;
        if (GameObject.Find("Medium").GetComponent<Toggle>().isOn) GameManager.quality = 2;
        if (GameObject.Find("High").GetComponent<Toggle>().isOn) GameManager.quality = 3;
        if (GameObject.Find("Very High").GetComponent<Toggle>().isOn) GameManager.quality = 4;
        if (GameObject.Find("Ultra").GetComponent<Toggle>().isOn) GameManager.quality = 5;
        QualitySettings.SetQualityLevel(GameManager.quality, true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFadeIn : MonoBehaviour
{
    public GameObject thisPanel;
    float fadeSpeed = 0.1f;
    Image fadeImage;
    bool isFadeIn;
    float alfa;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        alfa = fadeImage.color.a;
        isFadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {
            FadeIn();
        }
    }

    //フェードインさせる
    void FadeIn()
    {
        alfa -= fadeSpeed;
        SetAlfa();
        if(alfa <= 0)
        {

            isFadeIn = false;
            thisPanel.SetActive(false);
        }
    }

    //画面更新
    void SetAlfa()
    {
        fadeImage.color = new Color(0, 0, 0, alfa);
    }
}

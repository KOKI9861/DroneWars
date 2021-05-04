using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutController : MonoBehaviour
{

    float fadeSpeed = 0.01f;  //透明度が変わる速度を管理
    float red, green, blue, alfa;  //色、透明度を管理

    public bool isFadeOut = false;  //フェードアウトの開始、完了を管理するフラグ

    Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }


    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey("return") || Input.GetMouseButtonDown(0))
        {
            isFadeOut = true;
        }
        

        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlfa();
        if (alfa >= 1)
        {
            isFadeOut = false;
        }
    }

    void SetAlfa()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleLogoFadeIn : MonoBehaviour
{

    float fadeSpeed = 0.1f;
    public Text t;
    bool isFadeIn;
    float alfa;

    // Start is called before the first frame update
    void Start()
    {
        alfa = t.color.a;
        isFadeIn = false;
        Invoke("Call", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {
            FadeIn();
        }
    }

    // 4s経ったら呼ばれる
    void Call()
    {
        isFadeIn = true;
    }

    void FadeIn()
    {
        alfa += fadeSpeed;
        SetAlfa();
        if(alfa >= 1)
        {
            isFadeIn = false;
        }
    }

    void SetAlfa()
    {
        t.color = new Color(255, 255, 255, alfa);
    }
}

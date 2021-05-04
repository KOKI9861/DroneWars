using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFadeOut : MonoBehaviour
{

    float fadeSpeed = 0.1f;  //透明度が変わる速度を管理
    float red, green, blue, alfa;  //色、透明度を管理

    public bool isFadeOut = false;  //フェードアウトの開始、完了を管理するフラグ

    public Text t;

    // Start is called before the first frame update
    void Start()
    {
        alfa = t.color.a;
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
        alfa -= fadeSpeed;
        SetAlfa();
        if (alfa >= 1)
        {
            isFadeOut = false;
        }
    }

    void SetAlfa()
    {
        t.color = new Color(255, 255, 255, alfa);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFadeIn : MonoBehaviour
{

    float speed = 0.01f;
    float alfa;
    bool isFadeIn;
    Image fadeImage;

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

    void FadeIn()
    {
        alfa += speed;
        draw();
        if (alfa >= 1)
        {
            isFadeIn = false;
        }
    }

    void draw()
    {
        fadeImage.color = new Color(255, 255, 255, alfa);
    }
}

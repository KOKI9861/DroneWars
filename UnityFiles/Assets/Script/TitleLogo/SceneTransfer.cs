using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransfer : MonoBehaviour
{

    Image fadeImage;
    GameObject image_object;

    // Start is called before the first frame update
    void Start()
    {
        image_object = GameObject.Find("FadeImage");
        fadeImage = image_object.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("return") || Input.GetMouseButtonDown(0))
        {
            Invoke("Transfer", 4f);
        }
    }

    void Transfer()
    {
        //fadeImage.color = new Color(255, 255, 255, 0);
        SceneManager.LoadScene("Title");
    }
}

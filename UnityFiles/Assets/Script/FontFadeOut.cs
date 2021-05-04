using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FontFadeOut : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1 / fadeSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("Canvas").Find("Text").GetComponent<Text>().color = new Color(
            transform.Find("Canvas").Find("Text").GetComponent<Text>().color.r,
            transform.Find("Canvas").Find("Text").GetComponent<Text>().color.g,
            transform.Find("Canvas").Find("Text").GetComponent<Text>().color.b,
            transform.Find("Canvas").Find("Text").GetComponent<Text>().color.a - fadeSpeed * Time.deltaTime
            );
    }
}

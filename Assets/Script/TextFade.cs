using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TextFade : MonoBehaviour
{
    [SerializeField] private float inTime;
    [SerializeField] private float inSpeed;
    [SerializeField] private float outTime;
    [SerializeField] private float outSpeed;
    private float timer;
    void Start()
    {
        GameManager.isPause = false;
        Time.timeScale = 1f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > inTime && timer < outTime && GetComponent<Text>().color.a <= 1)
        {
            GetComponent<Text>().color = new Color(
            GetComponent<Text>().color.r,
            GetComponent<Text>().color.g,
            GetComponent<Text>().color.b,
            GetComponent<Text>().color.a + inSpeed * Time.deltaTime
            );
        }
        if(timer > outTime)
        {
            GetComponent<Text>().color = new Color(
            GetComponent<Text>().color.r,
            GetComponent<Text>().color.g,
            GetComponent<Text>().color.b,
            GetComponent<Text>().color.a - outSpeed * Time.deltaTime
            );
        }
    }
}

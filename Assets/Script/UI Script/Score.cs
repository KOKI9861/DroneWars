using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField] private Text _ScoreText;
    public float score;
    private float fullHp;
    private float currentHp;

    void Start()
    {
        score = 39f;
    }
    void Update()
    {
        _ScoreText.text = "Score : " + score;
    }

    public void ScoreUp(float n)
    {
        score += n;
    }
}

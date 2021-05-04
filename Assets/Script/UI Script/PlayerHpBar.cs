using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour {

    [SerializeField] private Slider _PlayerHpBar;
    [SerializeField] private Text _PlayerHpText;
    private bool gameSet;

    void Start()
    {
        gameSet = false;
    }
    void Update()
    {
        _PlayerHpText.text = "HP " + _PlayerHpBar.value + " / " + _PlayerHpBar.maxValue;
        if (_PlayerHpBar.value == 0 && !gameSet)
        {
            GameManager.gameEnd = -1;
            gameSet = true;
        }
    }

    public void HpChange(float changeHp)
    {
        _PlayerHpBar.value += changeHp;
    }
}

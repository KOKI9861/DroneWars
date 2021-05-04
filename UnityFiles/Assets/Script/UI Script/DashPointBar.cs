using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashPointBar : MonoBehaviour {

    //[SerializeField] private Text _EnemyHpText;
    [SerializeField] public Slider _DashPointBar;
    private float fullPoint;
    public float currentPoint;
    public float chargeSpeed = 20f;

    void Start()
    {
        fullPoint = 100f;
        currentPoint = fullPoint;
    }
    void Update()
    {
        if (currentPoint < 100f)
        {
            currentPoint += Time.deltaTime * chargeSpeed;
        }
        else if (currentPoint > 100f)
        {
            currentPoint = 100f;
        }
        _DashPointBar.value = currentPoint;
    }
}

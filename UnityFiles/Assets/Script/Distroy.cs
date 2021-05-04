using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distroy : MonoBehaviour
{
    [SerializeField] private float timer = 99f;
    void Start()
    {
        Destroy(gameObject, timer);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField] private float Speed = 30f;
    [SerializeField] private GameObject Ground;
    void Update()
    {
        transform.position = transform.position - Vector3.forward * Speed * Time.deltaTime;
        if (transform.position.z < -1500f)
        {
            Instantiate(Ground, new Vector3(-500f, 0f, 400f),Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PB : MonoBehaviour
{
    [SerializeField] private int moveType;

    private float moveSpeed = 400f;
    private float lifeTime = 5f;

    private float timer;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (transform.Find("Model") != null)
        {
            Move();
        }
        else
        {
            transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
    private void Move()
    {
        if (moveType == 0)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}

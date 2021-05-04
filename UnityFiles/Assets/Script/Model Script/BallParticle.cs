using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallParticle : MonoBehaviour
{
    [SerializeField] private float maxDistance = 0f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject pre;
    [SerializeField] private GameObject next;
    private float distanceN;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveTo = new Vector3(0f,0f,0f);
        float distanceP = Vector3.Distance(pre.transform.position, transform.position);
        if (distanceP > maxDistance)
        {
            moveTo += (pre.transform.position - transform.position);
        }
        float distanceN = Vector3.Distance(pre.transform.position, transform.position);
        if (distanceP > maxDistance)
        {
            moveTo += (pre.transform.position - transform.position);
        }

        transform.position += moveTo * speed * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashParticle : MonoBehaviour
{
    [SerializeField] private float maxDistance = 0f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject moveToObject;
    [SerializeField] private bool syncPos;



    // Update is called once per frame
    void Update()
    {
        if (syncPos)
        {
            transform.position = moveToObject.transform.position;
        }
        else
        {
            Vector3 moveTo = new Vector3(0f, 0f, 0f);
            float distanceP = Vector3.Distance(moveToObject.transform.position, transform.position);
            if (distanceP > maxDistance)
            {
                moveTo += (moveToObject.transform.position - transform.position);
            }

            if (speed * Time.deltaTime >= 1) transform.position += moveTo;
            else transform.position += moveTo * speed * Time.deltaTime;
        }
    }
}

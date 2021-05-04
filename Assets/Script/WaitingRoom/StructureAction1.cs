using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureAction1 : MonoBehaviour
{
    private float speedY = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, Time.deltaTime * speedY, 0f, Space.World);
        if (speedY > 0) speedY -= 20*Time.deltaTime;
        if (speedY < 0) speedY = 0f;
    }
    void OnTriggerEnter(Collider col)
    {
        speedY += 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleModel : MonoBehaviour
{
    [SerializeField] private GameObject[] scaled;
    [SerializeField] private GameObject[] scaling;
    [SerializeField] private float scaleUpTime = 0f;
    [SerializeField] private float scaleDownTime = 10f;
    [SerializeField] private float maxScale = 1f;
    [SerializeField] private float minScale = 0f;
    [SerializeField] private float scaleUpSecond = 1f;
    [SerializeField] private float scaleDownSecond = 1f;

    private float timer;
    private float destroyTime;
    void Start()
    {
        destroyTime = scaleDownTime + scaleDownSecond;
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= scaleUpTime && timer < scaleDownTime)
            for (int i = 0; i < scaling.Length; i++)
            {
                if (scaling[i].transform.localScale.x < maxScale) scaling[i].transform.localScale += new Vector3(1, 1, 1) * (Time.deltaTime / scaleUpSecond) * maxScale;
                if (scaling[i].transform.localScale.x > maxScale) scaling[i].transform.localScale = new Vector3(maxScale, maxScale, maxScale);
            }
        if (timer >= scaleDownTime)
            for (int i = 0; i < scaling.Length; i++)
            {
                if (scaling[i].transform.localScale.x > minScale) scaling[i].transform.localScale -= new Vector3(1, 1, 1) * (Time.deltaTime / scaleDownSecond) * maxScale;
                if (scaling[i].transform.localScale.x < minScale) scaling[i].transform.localScale = new Vector3(minScale, minScale, minScale);
            }

    }
}

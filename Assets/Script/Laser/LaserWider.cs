using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWider : MonoBehaviour
{
    [SerializeField] private float widerTime = 1f;
    [SerializeField] private float wideScaleEasy = 15f;
    [SerializeField] private float wideScaleNormal = 40f;
    [SerializeField] private float wideScaleHard = 70f;
    [SerializeField] private float wideScaleExpert = 100f;
    private float maxWideScale = 1f;
    [SerializeField] private float disWiderTime = 1f;
    [SerializeField] private float destroyTime = 3f;
    private float currentWideScale = 0f;
    private float timer;
    private bool stopWider;
    void Start()
    {
        Destroy(gameObject, destroyTime);
        SetStatus();
    }

    private void SetStatus()
    {
        if (GameManager.difficulty == "easy") maxWideScale = wideScaleEasy;
        if (GameManager.difficulty == "normal") maxWideScale = wideScaleNormal;
        if (GameManager.difficulty == "hard") maxWideScale = wideScaleHard;
        if (GameManager.difficulty == "expert" || GameManager.difficulty == "online") maxWideScale = wideScaleExpert;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //wider
        if (currentWideScale < maxWideScale && !stopWider)
            currentWideScale += Time.deltaTime / widerTime * maxWideScale;
        else if (currentWideScale >= maxWideScale && !stopWider) {
            currentWideScale = maxWideScale;
            stopWider = true;
        }

        //diswider
        if (timer >= destroyTime - disWiderTime && currentWideScale > 0)
        {
            stopWider = true;
            currentWideScale -= Time.deltaTime / disWiderTime * maxWideScale;
        }
       if (timer >= destroyTime - disWiderTime && currentWideScale < 0) currentWideScale = 0;

        transform.localScale = new Vector3(currentWideScale, currentWideScale, transform.localScale.z);
    }
}

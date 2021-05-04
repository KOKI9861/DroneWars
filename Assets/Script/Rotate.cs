using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate: MonoBehaviour {

    [SerializeField] private float speedX = 0f;
    [SerializeField] private float speedY = 20f;
    [SerializeField] private float speedZ = 0f;
    [SerializeField] private float SinSpeedX = 0f;
    [SerializeField] private float SinVelocityX = 1f;
    [SerializeField] private float SinStartDegreeX = 0f;
    [SerializeField] private float SinSpeedY = 0f;
    [SerializeField] private float SinVelocityY = 1f;
    [SerializeField] private float SinStartDegreeY = 0f;
    [SerializeField] private float SinSpeedZ = 0f;
    [SerializeField] private float SinVelocityZ = 1f;
    [SerializeField] private float SinStartDegreeZ = 0f;
    private float timer;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        transform.Rotate(new Vector3(Time.deltaTime * speedX + Time.deltaTime * Mathf.Sin(Mathf.PI * 2 * SinSpeedX * timer + SinStartDegreeX / Mathf.PI * 180)* SinVelocityX*Mathf.PI*2,
            Time.deltaTime * speedY + Time.deltaTime * Mathf.Sin(Mathf.PI * 2 * SinSpeedY * timer + SinStartDegreeY / Mathf.PI * 180)* SinVelocityY * Mathf.PI * 2,
            Time.deltaTime * speedZ + Time.deltaTime * Mathf.Sin(Mathf.PI * 2 * SinSpeedZ * timer + SinStartDegreeZ / Mathf.PI * 180)* SinVelocityZ * Mathf.PI * 2)) ;
    }
}

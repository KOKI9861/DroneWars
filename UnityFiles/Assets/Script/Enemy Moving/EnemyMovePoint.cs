using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovePoint: MonoBehaviour {

    private Vector3 initPos;
    private Vector3 newPos;
    private float timer;
    public float range = 10f;
    void Start () {
        initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            timer = 0f;
            newPos = initPos + new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
            transform.position = newPos;
        }
    }
}

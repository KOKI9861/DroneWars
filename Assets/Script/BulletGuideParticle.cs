using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGuideParticle : MonoBehaviour {
	void Start () {
        Destroy(gameObject, 1f);
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
	}
}

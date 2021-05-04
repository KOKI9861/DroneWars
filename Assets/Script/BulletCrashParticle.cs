using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCrashParticle : MonoBehaviour {
    private GameObject obj;
    void Start()
    {
        Destroy(gameObject, 0.5f);
        // 가까운 적 또는 플레이어를 찾을 수 있도록
        obj = GameObject.FindGameObjectWithTag("Player");
        if (obj == null) obj = GameObject.FindGameObjectWithTag("Boss");
        if (obj == null) obj = GameObject.FindGameObjectWithTag("Enemy");
        transform.LookAt(obj.transform);
    }
}

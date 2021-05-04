using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletGuide : MonoBehaviour {

    public GameObject _Particle;

    private GameObject parent;
    void Start()
    {
        parent = GameObject.Find("ETC");
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "EnemyBullet")
        {
            Quaternion _rotate = Quaternion.identity;
            GameObject.Find("ScorePanel").GetComponent<Score>().ScoreUp(20);
            Instantiate(_Particle, col.transform.position, _rotate).transform.parent = parent.transform;
        }
    }
}

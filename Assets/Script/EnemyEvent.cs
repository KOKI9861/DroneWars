using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvent : MonoBehaviour {

    public GameObject _Particle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PlayerBullet" || col.tag == "Player")
        {
            GameObject.Find("EnemyStatusPanel").GetComponent<EnemyHpBar>().HpChange(-1);
        }
        if (col.tag == "PlayerBullet")
        {
            Destroy(col.gameObject.transform.Find("Model").gameObject);
            Quaternion _rotate = Quaternion.identity;
            Instantiate(_Particle, col.transform.position, _rotate);
            GameObject.Find("ScorePanel").GetComponent<Score>().ScoreUp(4873);
        }
    }
}

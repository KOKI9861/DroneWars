using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour {

    public GameObject _Particle;
    private GameObject parent;
    private float damageTimer;
    [SerializeField] private float damageTerm = 0.5f;
    void Start ()
    {
        parent = GameObject.Find("ETC");
    }
	
	// Update is called once per frame
	void Update () {
        damageTimer += Time.deltaTime;
	}

    void OnTriggerEnter(Collider col)
    {
        if(!PlayerInformation.OnlineFlag){//シングルプレイ
            if (col.tag == "EnemyBullet" || col.tag == "Enemy" || col.tag == "Boss" || col.tag == "EnemyLaser")
            {
                if (damageTimer > damageTerm)
                {
                    GameObject.Find("PlayerStatusPanel").GetComponent<PlayerHpBar>().HpChange(-5);
                    damageTimer = 0f;
                }
            }
            if (col.tag == "EnemyBullet" || col.tag == "EnemyLaser")
            {
                Quaternion _rotate = Quaternion.identity;
                Instantiate(_Particle, col.transform.position, _rotate).transform.parent = parent.transform;
            }
            if (col.tag == "EnemyBullet")
            {
                Destroy(col.gameObject.transform.Find("Model").gameObject);
            }
        }
        else{//マルチプレイ
            if(GetComponent<PhotonView>().isMine){
                if (col.tag == "EnemyBullet" || col.tag == "Enemy" || col.tag == "Boss" || col.tag == "EnemyLaser")
                {
                    if (damageTimer > damageTerm)
                    {
                        GameObject.Find("PlayerStatusPanel").GetComponent<PlayerHpBar>().HpChange(-5);
                        damageTimer = 0f;
                    }
                }
                if (col.tag == "EnemyBullet" || col.tag == "EnemyLaser")
                {
                    Quaternion _rotate = Quaternion.identity;
                    PhotonManagerScript.Instantiate(_Particle, col.transform.position, _rotate).transform.parent = parent.transform;
                }
                if (col.tag == "EnemyBullet")
                {
                    PhotonManagerScript.Destroy(col.gameObject.transform.Find("Model").gameObject);
                }
            }
        }
    }
}

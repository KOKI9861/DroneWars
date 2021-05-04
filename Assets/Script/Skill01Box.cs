using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill01Box : MonoBehaviour
{

    public GameObject _Particle;
    private GameObject parent;
    void Start()
    {
        parent = GameObject.Find("ETC");
    }

    void OnTriggerEnter(Collider col)
    {
        // if (!PlayerInformation.OnlineFlag)
        {//シングルプレイ
            if (col.tag == "EnemyBullet")
            {
                Destroy(col.gameObject.transform.Find("Model").gameObject);
                Quaternion _rotate = Quaternion.identity;
                Instantiate(_Particle, col.transform.position, _rotate).transform.parent = parent.transform;
            }
        }
        // else
        // {//マルチプレイ
        //     // if (GetComponent<PhotonView>().isMine)
        //     {
        //         if (col.tag == "EnemyBullet")
        //         {
        //             PhotonManagerScript.Destroy(col.gameObject.transform.Find("Model").gameObject);
        //             Quaternion _rotate = Quaternion.identity;
        //             PhotonManagerScript.Instantiate(_Particle, col.transform.position, _rotate).transform.parent = parent.transform;
        //         }
        //     }
        // }
    }
}

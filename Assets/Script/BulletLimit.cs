using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLimit : MonoBehaviour
{
    [SerializeField] private GameObject destroyParticle;
    private GameObject parent;

    private void Start()
    {
        parent = GameObject.Find("ETC");
    }
    void OnTriggerExit(Collider col)
    {
        if(!PlayerInformation.OnlineFlag){//シングルプレイ
            if (col.tag == "PlayerBullet" || col.tag == "EnemyBullet")
            {
                Instantiate(destroyParticle, col.gameObject.transform.position, Quaternion.LookRotation((col.gameObject.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized)).transform.parent = parent.transform;
                Destroy(col.gameObject, 5f);
                Destroy(col.gameObject.transform.Find("Model").gameObject);
            }
            if (col.tag == "Enemy")
            {
                Destroy(col.gameObject);
            }
        }else{//マルチプレイ
            if (col.tag == "PlayerBullet")
            {
                Instantiate(destroyParticle, col.gameObject.transform.position, Quaternion.LookRotation((col.gameObject.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized)).transform.parent = parent.transform;
                Destroy(col.gameObject, 5f);
                Destroy(col.gameObject.transform.Find("Model").gameObject);
            }
                        
            
            if (col.tag == "EnemyBullet")
            {
                PhotonManagerScript.Instantiate(destroyParticle, col.gameObject.transform.position, Quaternion.LookRotation((col.gameObject.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized)).transform.parent = parent.transform;
                Destroy(col.gameObject, 5f);
                // PhotonManagerScript.Destroy(col.gameObject);
                PhotonManagerScript.Destroy(col.gameObject.transform.Find("Model").gameObject);
                // Destroy(col.gameObject.transform.Find("Model").gameObject);

            }
            if (col.tag == "Enemy")
            {
                PhotonManagerScript.Destroy(col.gameObject);
            }
        }
        
    }
}

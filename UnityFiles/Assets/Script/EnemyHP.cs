using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("EnemyHp : " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PlayerBullet" || col.tag == "PlayerPivot")
        {
            GameObject.Find("EnemyStatusPanel").GetComponent<EnemyHpBar>().HpChange(-1);
        }
        if (col.tag == "PlayerBullet")
        {
            Destroy(col.gameObject.transform.Find("BulletModel").gameObject);
            Quaternion _rotate = Quaternion.identity;
            GameObject.Find("ScorePanel").GetComponent<Score>().ScoreUp(4873);
        }
    }
}

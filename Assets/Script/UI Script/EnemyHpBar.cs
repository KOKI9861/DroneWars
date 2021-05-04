using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour {

    [SerializeField] private Slider _EnemyHpBar;
    private bool gameSet;

    void Start()
    {
        gameSet = false;
    }

    void Update()
    {
        if (_EnemyHpBar.value == 0 && !gameSet)
        {
            GameManager.gameEnd = 1;
            gameSet = true;
        }
    }

    public void HpChange(float changeHp)
    {
        if(!PlayerInformation.OnlineFlag){
            HpChangeRPC(changeHp);
                Debug.Log("atattayo!");
        }else{
            // if(GetComponent<PhotonView>().isMine)
            {
                GetComponent<PhotonView>().RPC("HpChangeRPC",PhotonTargets.AllViaServer,changeHp);
                Debug.Log("atatta!");
            }
        }
        // _EnemyHpBar.value += changeHp;
        
    }

    [PunRPC]
    public void HpChangeRPC(float changeHp){
        _EnemyHpBar.value += changeHp;
        Debug.Log("kougeki!");

    }
}

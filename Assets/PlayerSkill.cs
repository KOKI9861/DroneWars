using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private string skillName = "safeCube";
    [SerializeField] private GameObject[] skillObject;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(skillName == "safeCube")
            {
                if(!PlayerInformation.OnlineFlag){
                    makeSafeCube(transform.position);

                }else{
                    if(GetComponent<PhotonView>().isMine){
                        makeSafeCube(transform.position);
                        GetComponent<PhotonView>().RPC("makeSafeCube",PhotonTargets.Others,transform.position);

                    }
                        
                }
                // if(!PlayerInformation.OnlineFlag){
                //     Instantiate(skillObject[0]).transform.position = transform.position + new Vector3(0, 2, 0);
                // }else{
                //     if(GetComponent<PhotonView>().isMine){
                //         PhotonManagerScript.Instantiate(skillObject[0],new Vector3(0,0,0),Quaternion.identity).transform.position = transform.position + new Vector3(0, 2, 0);
                //     }
                        
                // }
            }
        }
    }


    [PunRPC]
    void makeSafeCube(Vector3 position){
        Instantiate(skillObject[0]).transform.position = position + new Vector3(0, 2, 0);

    }
}

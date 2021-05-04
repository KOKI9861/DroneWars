// このスクリプトはたぶんいらない

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonPlayerBullet : Photon.PunBehaviour
{
    [SerializeField] private GameObject bulletType;
    private GameObject parent;
    [SerializeField] private int positionType;
    [SerializeField] private int rotationType;
    [SerializeField] private float deltaTime = 0.1f;

    private float timer;
    private float deltaTimer;
    private bool cycleEnd;
    private Vector3 initPos;
    private Quaternion initRot;

    //仮の変数
    private bool tBool1;

    void Start()
    {
        
        parent = GameObject.Find("Player0s");

    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        deltaTimer += Time.deltaTime;
        if (deltaTimer > deltaTime && Input.GetMouseButton(0))
        {
            cycleEnd = false;
            while (!cycleEnd)
            {
                SetPosition();
                SetRotation();
                InitBullet();
            }
            deltaTimer = 0;
        }
    }

    private void SetPosition()
    {
        if (positionType == 0)
        {
            initPos = transform.position;
            cycleEnd = true;
        }
        if (positionType == 1)
        {
            if (tBool1 == false)
            {
                initPos = transform.position + transform.right * 2f;
                tBool1 = true;
            }
            else if (tBool1 == true)
            {
                initPos = transform.position - transform.right * 2f;
                tBool1 = false;
                cycleEnd = true;
            }
        }
    }
    private void SetRotation()
    {
        if (rotationType == 0)
        {
            if (initPos == transform.position)
            {
                initRot = transform.rotation;
            }
            else
            {
                initRot = transform.rotation;
                //initRot = Quaternion.LookRotation((initPos - transform.position).normalized);
            }
        }
    }
    private void InitBullet()
    {
        Debug.Log("Bullet");
        PhotonNetwork.Instantiate(bulletType.name, initPos, initRot,0).transform.parent = parent.transform;
        //AudioSource effectSound = GetComponent<AudioSource>();
        //effectSound.Play();
        AudioSource.PlayClipAtPoint(GameObject.Find("GameManager").GetComponent<SoundManager>().effectSound[0], transform.position);
    }
}

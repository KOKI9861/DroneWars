using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EB : MonoBehaviour
{
    [SerializeField] private string moveType;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float fasterSpeed = 0f;
    [SerializeField] private float destroyObjectDelay = 3f;


    private GameObject nearPlayer;
    private Vector3 fixedInitPos;
    private Vector3 fixedTargetPos;
    private bool destroyed;
    private Quaternion rotDim, rotDimFactor; 

    private float timer;
    void Start()
    {
        // 필요하면 초기 로테이션 함수를 넣자
        FindNearPlayer();
        if (moveType == "toPlayer") transform.LookAt(nearPlayer.transform);
        fixedInitPos = transform.position;
        fixedTargetPos = nearPlayer.transform.position;
    }
    void Update()
    {
        timer += Time.deltaTime;
        FindNearPlayer();
        Faster();
        PreMove();
    }

    // 一番近くのプレイヤオブジェクトの変数を nearPlayerに保存
    private void FindNearPlayer()
    {
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");
        if (playerList.Length != 0)
        {
            nearPlayer = playerList[0];
            for (int i = 0; i < playerList.Length; i++)
            {
                if (Vector3.Distance(transform.position, nearPlayer.transform.position) > Vector3.Distance(transform.position, playerList[i].transform.position))
                    nearPlayer = playerList[i];
            }
        }
    }

    private void Faster()
    {
        moveSpeed += fasterSpeed * Time.deltaTime;
    }

    private void PreMove()
    {
        if (transform.Find("Model") != null)
        {
            Move();
        }
        else
        {
            transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            destroyed = true;
        }
        if (destroyed)
        {
            Destroy(gameObject, destroyObjectDelay);
        }
    }

    private void Move()
    {
        // 곧바로 앞으로 moveSpeed 속도로
        if (moveType == "forward")
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        // (가까운)플레이어 방향으로 moveSpeed 속도로
        if (moveType == "toPlayer")
        {
            transform.position += (fixedTargetPos - fixedInitPos).normalized * moveSpeed * Time.deltaTime;
        }
        if (moveType == "test1")
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime / 2;
            transform.position += (nearPlayer.transform.position - fixedInitPos).normalized * moveSpeed * Time.deltaTime / 2;
        }
        // Test move
        if (moveType == "test")
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime/2;
            transform.position += (nearPlayer.transform.position - fixedInitPos).normalized * moveSpeed * Time.deltaTime/2;
        }
        // Special move 01
        if(moveType == "special01")
        {
            //rotDim = transform.rotation - rotDimFactor;
            
            transform.position += transform.forward * moveSpeed * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, nearPlayer.transform.position - transform.position, moveSpeed * Time.deltaTime * 0.1f, 0.0f));

            if(moveSpeed<10)moveSpeed += Time.deltaTime;
            rotDimFactor = transform.rotation;
        }
    }
}

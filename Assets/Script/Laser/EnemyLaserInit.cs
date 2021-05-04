using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserInit : MonoBehaviour
{

    [SerializeField] private bool all, easy, normal, hard, expert;

    [SerializeField] private GameObject laserParticle;
    [SerializeField] private GameObject readyLaserParticle;
    [SerializeField] private string readyLaserType = "default";
    [SerializeField] private string laserType = "default";
    [SerializeField] private float deltaTime;
    [SerializeField] private int repeatNumber = 999999;
    [SerializeField] private float repeatTerm = 1f;
    private GameObject parent;
    [SerializeField] private float startTime = 0f;
    [SerializeField] private float endTime = 999999f;
    [SerializeField] private float laserDelay = 2f;
    private float distance;
    [SerializeField] private float overDistance = 100f;


    private float timer;
    private float deltaTimer;
    private float repeatTimer;
    private int repeatNow;
    private bool oneCycleEnd;
    private int num;
    private Vector3[] saveFrom;
    private Vector3[] saveTo;
    private float[] saveDistance;
    private float[] laserCounter;
    private bool[] isCounting;
    private int laserCounterMaxNumber = 10;

    private GameObject nearPlayer;
    void Start()
    {
        parent = GameObject.Find("Enemys");
        repeatTimer = repeatTerm - startTime;
        laserCounter = new float[laserCounterMaxNumber];
        isCounting = new bool[laserCounterMaxNumber];
        saveFrom = new Vector3[laserCounterMaxNumber];
        saveTo = new Vector3[laserCounterMaxNumber];
        saveDistance = new float[laserCounterMaxNumber];
    }

    // Update is called once per frame
    void Update()
    {
        if (all)
        {
            if (all)
            {
                FindNearPlayer();
                Ready();
            }
        }
        else if (GameManager.difficulty == "easy")
        {
            if (easy)
            {
                FindNearPlayer();
                Ready();
            }
        }
        else if (GameManager.difficulty == "normal")
        {
            if (normal)
            {
                FindNearPlayer();
                Ready();
            }
        }
        else if (GameManager.difficulty == "hard")
        {
            if (hard)
            {
                FindNearPlayer();
                Ready();
            }
        }
        else if (GameManager.difficulty == "expert")
        {
            if (expert)
            {
                FindNearPlayer();
                Ready();
            }
        }
    }
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

    void Ready()
    {

        timer += Time.deltaTime;
        repeatTimer += Time.deltaTime;
        deltaTimer += Time.deltaTime;

        if (repeatNow < repeatNumber && repeatTimer > repeatTerm)
        {
            if (startTime < timer && timer < endTime && deltaTimer > deltaTime)
            {
                while (!oneCycleEnd)
                {
                    InitReadyLaser();
                    deltaTimer = 0;
                }
            }
            if (oneCycleEnd)
            {
                oneCycleEnd = false;
                repeatNow++;
                repeatTimer -= repeatTerm;


                laserCounter[num] = 0;
                saveFrom[num] = transform.position;
                saveTo[num] = nearPlayer.transform.position;
                saveDistance[num] = Vector3.Distance(nearPlayer.transform.position, transform.position);
                isCounting[num] = true;
                num++;
                if (num >= laserCounterMaxNumber) num = 0;
            }
        }
        for(int i=0;i< laserCounterMaxNumber; i++)
        {
            if (isCounting[i] == true)
            {
                laserCounter[i] += Time.deltaTime;
                if (laserCounter[i] > laserDelay)
                {
                    isCounting[i] = false;
                    laserCounter[i] = 0;
                    InitLaser(i);
                }
            }
        }
    }
    void InitReadyLaser()
    {
        if (readyLaserType == "default")
        {
            distance = Vector3.Distance(nearPlayer.transform.position, transform.position);
            for (int i = 0; i < distance + overDistance; i += 15)
            {
                Vector3 initPos = transform.position + (nearPlayer.transform.position - transform.position).normalized * i;
                Instantiate(readyLaserParticle, initPos, Quaternion.LookRotation((nearPlayer.transform.position - transform.position).normalized),GameObject.Find("ETC").transform);
            }
        }
        oneCycleEnd = true;
    }
    void InitLaser(int n)
    {
        if (laserType == "default")
        {
            Vector3 initPos = saveFrom[n];
            Instantiate(laserParticle, initPos, Quaternion.LookRotation((saveTo[n] - saveFrom[n]).normalized), GameObject.Find("Enemys").transform).transform.localScale = new Vector3(0f, 0f, saveDistance[n] + 500f);
        }
    }
}
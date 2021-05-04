using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletInit : MonoBehaviour
{
    [SerializeField] private bool all, easy, normal, hard, expert;

    [SerializeField] private GameObject bulletType;
    private GameObject parent;
    [SerializeField] private float startTime = 0f;
    [SerializeField] private float endTime = 999999f;
    [SerializeField] private string positionType = "default";
    [SerializeField] private string rotationType = "fromSrc";
    [SerializeField] private int deltaType;
    [SerializeField] private float deltaTime;
    [SerializeField] private int repeatNumber = 999999;
    [SerializeField] private float repeatTerm = 1f;
    [SerializeField] private float valuePA;
    [SerializeField] private float valuePB;
    [SerializeField] private float valuePC;
    [SerializeField] private float valuePD;
    [SerializeField] private float valuePE;
    private float tmpPA;
    private float tmpPB;
    private float tmpPC;
    private float tmpPD;
    private float tmpPE;
    [SerializeField] private float valueRA;
    [SerializeField] private float valueRB;
    [SerializeField] private float valueRC;
    [SerializeField] private float valueRD;
    [SerializeField] private float valueRE;
    private float tmpRA;
    private float tmpRB;
    private float tmpRC;
    private float tmpRD;
    private float tmpRE;

    private float timer;
    private float deltaTimer;
    private float repeatTimer;
    private int repeatNow;
    private bool oneCycleEnd;

    private Vector3 initPos;
    private Quaternion initRot;
    private GameObject nearPlayer;
    private void Start()
    {
        parent = GameObject.Find("Enemys");
        repeatTimer = repeatTerm - startTime;
    }

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
        else if (GameManager.difficulty == "expert" || GameManager.single_multi == "multi")
        {
            if (expert)
            {
                FindNearPlayer();
                Ready();
            }
        }
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
    private void Ready()
    {
        timer += Time.deltaTime;
        repeatTimer += Time.deltaTime;
        deltaTimer += Time.deltaTime;

        //if(transform.tag == "Boss")
        if (repeatNow < repeatNumber && repeatTimer > repeatTerm)
        {
            if (startTime < timer && timer < endTime && deltaTimer > deltaTime)
            {
                while (!oneCycleEnd)
                {
                    SetPosition();
                    SetRotation();
                    InitBullet();
                    deltaTimer = 0;
                }
            }
            if (oneCycleEnd)
            {
                oneCycleEnd = false;
                repeatNow++;
                repeatTimer -= repeatTerm;
            }
        }
    }

    private void SetPosition()
    {
        // 적 위치에서 생성
        if (positionType == "default")
        {
            initPos = transform.position;
            oneCycleEnd = true;
        }
        // 적->플레이어 방향으로 가로 일자로 생성. 인자는 두 개(탄 수, 간격)
        if (positionType == "straight01")
        {
            Quaternion tmpRot = transform.rotation;
            transform.LookAt(nearPlayer.transform);
            initPos = transform.position + transform.right*(tmpPA - valuePA/2)/valuePA * 2 * valuePB;
            tmpPA++;
            if (tmpPA > valuePA)
            {
                tmpPA = 0;
                oneCycleEnd = true;
            }
            transform.rotation = tmpRot;
        }
        // 적->플레이어 방향으로 세로 둘레로 생성. 인자는 세 개(탄 수, 거리, 중첩)
        if (positionType == "circle01")
        {
            Quaternion tmpRot = transform.rotation;
            transform.LookAt(nearPlayer.transform);
            if (tmpPC == 0) tmpPC = 1;
            initPos = transform.position + (transform.right * Mathf.Cos(Mathf.PI * 2 / valuePA * tmpPA) * valuePB * tmpPC)
                + (transform.up * Mathf.Sin(Mathf.PI * 2 / valuePA * tmpPA) * valuePB * tmpPC);
            tmpPA++;
            if (tmpPA > valuePA)
            {
                tmpPA = 0;
                tmpPC++;
            }
            if (tmpPC > valuePC)
            {
                tmpPC = 1;
                oneCycleEnd = true;
            }
            transform.rotation = tmpRot;

        }
        // 적->플레이어 방향으로 가로 둘레로 생성. 인자는 세 개(탄 수, 거리, 중첩)
        if (positionType == "circle02")
        {
            Quaternion tmpRot = transform.rotation;
            transform.LookAt(nearPlayer.transform);
            if (tmpPC == 0) tmpPC = 1;
            initPos = transform.position + (transform.right * Mathf.Cos(Mathf.PI * 2 / valuePA * tmpPA) * valuePB * tmpPC)
                + (transform.forward * Mathf.Sin(Mathf.PI * 2 / valuePA * tmpPA) * valuePB * tmpPC);
            tmpPA++;
            if (tmpPA > valuePA)
            {
                tmpPA = 0;
                tmpPC++;
            }
            if (tmpPC > valuePC)
            {
                tmpPC = 1;
                oneCycleEnd = true;
            }
            transform.rotation = tmpRot;

        }
        // 적을 둘러싼 구체 형태로 생성. 인자는 네 개(위도탄수, 적도탄수, 중첩수, 거리)
        if (positionType == "sphere01")
        {
            Quaternion tmpRot = transform.rotation;
            transform.LookAt(nearPlayer.transform);
            // 시작
            initPos = transform.position + new Vector3(Mathf.Cos(Mathf.PI * 2f / valuePA * tmpPA/2 - Mathf.PI/2 + Mathf.PI / valuePA / 2) * Mathf.Cos(Mathf.PI * 2f / valuePB * tmpPB) * (tmpPC + 1f) * valuePD,
                Mathf.Sin(Mathf.PI * 2f / valuePA * tmpPA / 2 - Mathf.PI / 2 + Mathf.PI / valuePA / 2) * (tmpPC + 1f) * valuePD,
                Mathf.Cos(Mathf.PI * 2f / valuePA * tmpPA / 2 - Mathf.PI / 2 + Mathf.PI / valuePA / 2) * Mathf.Sin(Mathf.PI * 2f / valuePB * tmpPB) * (tmpPC + 1f) * valuePD);
            if (tmpPC < valuePC-1) tmpPC++;
            else
            {
                tmpPC = 0f;
                if (tmpPB < valuePB-1) tmpPB++;
                else
                {
                    tmpPB = 0f;
                    if (tmpPA < valuePA-1) tmpPA++;
                    else
                    {
                        tmpPA = 0f;
                        oneCycleEnd = true;
                        return;

                    }
                }
            }
            transform.rotation = tmpRot;
        }
        // 적을 둘러싼 큐브 형태로 생성
        if (positionType == "cube01")
        {
            initPos = transform.position + new Vector3(tmpPA - (valuePA - 1) / 2, tmpPB - (valuePA - 1) / 2, tmpPC - (valuePA - 1) / 2) * (tmpPD + 1) / valuePA * valuePC;
            if (tmpPD < valuePB) tmpPD++;
            else {
                tmpPD = 0;
                if (tmpPC < valuePA) tmpPC++;
                else {
                    tmpPC = 0;
                    if (tmpPB < valuePA) tmpPB++;
                    else {
                        tmpPB = 0;
                        if (tmpPA < valuePA) tmpPA++;
                        else
                        {
                            tmpPA = 0;
                            oneCycleEnd = true;
                            return;
                        }
                    }
                }
            }
        }
    }
    private void SetRotation()
    {
        // 적 위치와 반대 방향을 바라봄. 같은 위치 생성인 경우, 적이 보는 방향을 바라봄
        if (rotationType == "fromSrc")
        {
            if (initPos == transform.position)
            {
                initRot = transform.rotation;
            }
            else
            {
                initRot = Quaternion.LookRotation((initPos - transform.position).normalized);
            }
        }
        // 탄이 가까운 플레이어를 바라보도록 생성
        if(rotationType == "toPlayer")
        {
            initRot = Quaternion.LookRotation((nearPlayer.transform.position - initPos).normalized);
        }
        // 적이보는 플레이어 방향으로 생성
        if (rotationType == "fromSrcToPlayer")
        {
            initRot = Quaternion.LookRotation((nearPlayer.transform.position - transform.position).normalized);
        }
        if (rotationType == "Vector3")
        {
            initRot = Quaternion.LookRotation(Vector3.RotateTowards(new Vector3(0, 0, 0), new Vector3(tmpRA, tmpRB, tmpRC), 10f, 10f));
        }
    }
    private void InitBullet()
    {
        if(!PlayerInformation.OnlineFlag){
            Instantiate(bulletType, initPos, initRot).transform.parent = parent.transform;
        }else{
            // bulletType.GetComponent<PhotonView>().viewID = 2;
            PhotonManagerScript.InstantiateSceneObject(bulletType, initPos, initRot).transform.parent = parent.transform;
        }
    }
}

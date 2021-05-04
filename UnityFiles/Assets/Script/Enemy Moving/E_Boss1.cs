using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class E_Boss1 : MonoBehaviour
{

    [SerializeField] private float easyMoveSpeed = 0.25f;
    [SerializeField] private float easyInitY = 60f;
    [SerializeField] private float easyRadius = 80f;
    [SerializeField] private float easyHp = 600f;
    [SerializeField] private float normalMoveSpeed = 0.3f;
    [SerializeField] private float normalInitY = 70f;
    [SerializeField] private float normalRadius = 100f;
    [SerializeField] private float normalHp = 800f;
    [SerializeField] private float hardMoveSpeed = 0.35f;
    [SerializeField] private float hardInitY = 80f;
    [SerializeField] private float hardRadius = 140f;
    [SerializeField] private float hardHp = 1000f;
    [SerializeField] private float expertMoveSpeed = 0.4f;
    [SerializeField] private float expertInitY = 100f;
    [SerializeField] private float expertRadius = 180f;
    [SerializeField] private float expertHp = 1500f;
    private float moveSpeed = 0.25f;
    private float initY = 60f;
    private float radius = 80f;
    private float maxHp = 600f;
    private float hp = 600f;
    [SerializeField] private GameObject _Particle;
    [SerializeField] private GameObject destroyParticle;
    private bool dead = false;

    private Vector3 newPos;
    private float timer;
    void Start()
    {
        GameObject.Find("HUD").transform.Find("StatusPanel").transform.Find("BossStatusPanel").gameObject.active = true;
        GameObject.Find("HUD").transform.Find("StatusPanel").transform.Find("BossStatusPanel").transform.Find("BossHpBar").GetComponent<Slider>().maxValue = maxHp;
        GameObject.Find("HUD").transform.Find("StatusPanel").transform.Find("BossStatusPanel").transform.Find("BossHpBar").GetComponent<Slider>().value = hp;
        SetStatus();
    }
    private void SetStatus()
    {
        if (GameManager.difficulty == "easy"){
            moveSpeed = easyMoveSpeed;
            initY = easyInitY;
            radius = easyRadius;
            maxHp = easyHp;
            hp = maxHp;
        }
        if (GameManager.difficulty == "normal"){
            moveSpeed = normalMoveSpeed;
            initY = normalInitY;
            radius = normalRadius;
            maxHp = normalHp;
            hp = maxHp;
        }
        if (GameManager.difficulty == "hard"){
            moveSpeed = hardMoveSpeed;
            initY = hardInitY;
            radius = hardRadius;
            maxHp = hardHp;
            hp = maxHp;
        }
        if (GameManager.difficulty == "expert" || GameManager.difficulty == "online"){
            moveSpeed = expertMoveSpeed;
            initY = expertInitY;
            radius = expertRadius;
            maxHp = expertHp;
            hp = maxHp;
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        Move();
        FixForce();
        UpdateHP();
    }
    public void Move()
    {
        newPos = new Vector3(Mathf.Sin(timer * moveSpeed) * radius, initY + Mathf.Sin(timer * moveSpeed * 4) * 10, Mathf.Cos(timer * moveSpeed) * radius);
        transform.position = newPos;
        // '가까운' 플레이어를 바라보도록 개선
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").gameObject.transform);
    }
    private void FixForce()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }
    private void UpdateHP()
    {
        if (GameObject.Find("HUD").transform.Find("StatusPanel").transform.Find("BossStatusPanel").gameObject.active)
        {
            transform.Find("Canvas").Find("Slider").transform.GetComponent<Slider>().maxValue = maxHp;
            transform.Find("Canvas").Find("Slider").transform.GetComponent<Slider>().value = hp;
            GameObject.Find("HUD").transform.Find("StatusPanel").transform.Find("BossStatusPanel").transform.Find("BossHpBar").GetComponent<Slider>().maxValue = maxHp;
            GameObject.Find("HUD").transform.Find("StatusPanel").transform.Find("BossStatusPanel").transform.Find("BossHpBar").GetComponent<Slider>().value = hp;
            Debug.Log("hp:"+hp);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(!PlayerInformation.OnlineFlag){//シングルプレイ
            if (col.tag == "PlayerBullet" || col.tag == "Player")
            {
                hp--;
            }
            if (col.tag == "PlayerBullet")
            {
                Destroy(col.gameObject.transform.Find("Model").gameObject);
                Quaternion _rotate = Quaternion.identity;
                Instantiate(_Particle, col.transform.position, _rotate);
                GameObject.Find("ScorePanel").GetComponent<Score>().ScoreUp(100);
                hp--;
            }
            if (hp <= 0 && !dead)
            {
                GameObject.Find("ScorePanel").GetComponent<Score>().ScoreUp(10000);
                dead = true;
                Instantiate(destroyParticle, transform.position, Quaternion.LookRotation((transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized));
                Destroy(transform.Find("Canvas").gameObject);
                Destroy(transform.Find("Model").gameObject);
                GameManager.gameEnd = 1;
                Destroy(gameObject, 10f);
            }
        }else{//マルチプレイ
            if (col.tag == "PlayerBullet" || col.tag == "Player")
            {
                GetComponent<PhotonView>().RPC("changeHP",PhotonTargets.AllViaServer);
            }
            if (col.tag == "PlayerBullet")
            {
                Destroy(col.gameObject.transform.Find("Model").gameObject);
                // PhotonManagerScript.Destroy(col.gameObject.transform.Find("Model").gameObject);
                Quaternion _rotate = Quaternion.identity;
                PhotonManagerScript.InstantiateSceneObject(_Particle, col.transform.position, _rotate);
                GameObject.Find("ScorePanel").GetComponent<Score>().ScoreUp(100);
                GetComponent<PhotonView>().RPC("changeHP",PhotonTargets.AllViaServer);
            }
            if (hp <= 0 && !dead)
            {
                GameObject.Find("ScorePanel").GetComponent<Score>().ScoreUp(10000);
                dead = true;
                PhotonManagerScript.InstantiateSceneObject(destroyParticle, transform.position, Quaternion.LookRotation((transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized));
                PhotonManagerScript.Destroy(transform.Find("Canvas").gameObject);
                PhotonManagerScript.Destroy(transform.Find("Model").gameObject);
                GameManager.gameEnd = 1;
                PhotonManagerScript.Destroy(gameObject, 10f);
            }
        }
        
    }

    [PunRPC]
    void changeHP(){
        hp--;
    }
}

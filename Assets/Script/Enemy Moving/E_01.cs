using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_01 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxHp = 5f;
    [SerializeField] private float hp = 5f;
    [SerializeField] private GameObject _Particle;
    [SerializeField] private GameObject destroyParticle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpdateHP();
    }
    private void Move()
    {
        transform.position = transform.position - Vector3.forward * Time.deltaTime * moveSpeed;
    }
    private void UpdateHP()
    {
        transform.Find("Canvas").Find("Slider").transform.GetComponent<Slider>().maxValue = maxHp;
        transform.Find("Canvas").Find("Slider").transform.GetComponent<Slider>().value = hp;
    }
    void OnTriggerEnter(Collider col)
    {
        
        if(!PlayerInformation.OnlineFlag){
            if (col.tag == "PlayerBullet" || col.tag == "Player")
            {
                hp--;
            }
            if (col.tag == "PlayerBullet")
            {
                Destroy(col.gameObject.transform.Find("Model").gameObject);
                Quaternion _rotate = Quaternion.identity;
                Instantiate(_Particle, col.transform.position, _rotate);
                hp--;
            }
            if (hp < 0)
            {
                GameObject.Find("ScorePanel").GetComponent<Score>().ScoreUp(4873);
                Instantiate(destroyParticle, transform.position, Quaternion.LookRotation((transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized));
                Destroy(gameObject);
            }
        }else{
            if (col.tag == "PlayerBullet" || col.tag == "Player")
            {
                GetComponent<PhotonView>().RPC("changeHP",PhotonTargets.AllViaServer);
            }
            if (col.tag == "PlayerBullet")
            {
                Destroy(col.gameObject.transform.Find("Model").gameObject);
                Quaternion _rotate = Quaternion.identity;
                Instantiate(_Particle, col.transform.position, _rotate);
                GetComponent<PhotonView>().RPC("changeHP",PhotonTargets.AllViaServer);
            }
            if (hp < 0)
            {
                GameObject.Find("ScorePanel").GetComponent<Score>().ScoreUp(4873);
                Instantiate(destroyParticle, transform.position, Quaternion.LookRotation((transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized));
                Destroy(gameObject);
            }
        }
    }

    [PunRPC]
    void changeHP(){
        hp--;
    }
}

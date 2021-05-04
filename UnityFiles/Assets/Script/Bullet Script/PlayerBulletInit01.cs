using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletInit01 : MonoBehaviour
{
    GameObject _GameManager;
    GameObject _Obj;
    GameObject _Src;
    public GameObject _InitObj;
    private int posNo = 0;
    private int rotNo = 0;
    private Vector3 _position;
    private Quaternion _rotation;
    private float[] factorOfPosition;
    private float[] factorOfRotation;
    public float initDelta = 0.1f;
    private float timer = 0f;

    void Start()
    {
        _GameManager = GameObject.Find("GameManager");
        _Obj = GameObject.Find("Enemy");
        _Src = gameObject;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (timer > initDelta)
            {
                timer = 0f;
                InitObject();
            }
        }
    }
    private void InitObject()
    {
        // (GameObject Src, GameObject Obj, int no, float[] factor)
        _position = _GameManager.GetComponent<BulletManager>().InitPosition(_Src, _Obj, posNo, factorOfPosition);
        _rotation = _GameManager.GetComponent<BulletManager>().InitRotation(_Src, _Obj, rotNo, factorOfRotation);

        Instantiate(_InitObj, _position, _rotation);
    }
}

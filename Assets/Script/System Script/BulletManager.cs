// BulletManagerオブジェクトに適用

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletManager : MonoBehaviour {

    void Start()
    {
    }
    void Update()
    {
    }

    // ShooterのGenerate.csから呼び出し
    public void BulletInit(GameObject Shooter, GameObject Target, GameObject Bullet, int posNo, int rotateNo)
    {
        Vector3 shooterPos = Shooter.transform.position;
        Vector3 outputPos = shooterPos;

        if (posNo == 1)
        {
            int dis = 10;
            int num = 3;
            for (int i = -num; i < num + 1; i++)
            {
                for (int j = -num; j < num + 1; j++)
                {
                    outputPos = new Vector3(shooterPos.x + i * dis, shooterPos.y + j * dis, shooterPos.z);
                    BulletShoot(Shooter, Target, Bullet, outputPos, rotateNo, i, j, 0, 0);
                }
            }
        }

        if (posNo == 2)
        {
            float a = 5f;
            float b = 1f;
            float distance = 10f;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    for (int k = 0; k < a; k++)
                    {
                        for (int l = 0; l < b; l++)
                        {
                            outputPos = shooterPos + new Vector3(i - (a - 1) / 2, j - (a - 1) / 2, k - (a - 1) / 2).normalized * (l + 1) * distance;
                            BulletShoot(Shooter, Target, Bullet, outputPos, rotateNo, i, j, k, l);
                        }
                    }
                }
            }
        }

    }
    private void BulletShoot(GameObject Shooter, GameObject Target, GameObject Bullet, Vector3 _position, int rotateNo, int i, int j, int k, int l)
    {
        Quaternion _rotate = Shooter.transform.rotation;

        //Rotation
        if (rotateNo == 0)
        {
            _rotate = Shooter.transform.rotation;
        }
        if (rotateNo == 1)
        {
            _rotate = Quaternion.identity;
        }

        Instantiate(Bullet, _position, _rotate);

    }

    public Vector3 InitPosition(GameObject Src, GameObject Obj, int no, float[] factor)
    {
        Vector3 _position = Src.transform.position;

        // At Src
        if (no == 0)
        {
            _position = Src.transform.position;
            return _position;
        }

        // Src + (x,y,z)*distance
        if (no == 1) // factor[0]:x factor[1]:y factor[2]:z factor[3]:distance
        {
            _position = Src.transform.position + new Vector3(factor[0], factor[1], factor[2]);
        }

        return _position;
    }
    public Quaternion InitRotation(GameObject Src, GameObject Obj, int no, float[] factor)
    {
        Quaternion _rotation = Src.transform.rotation;

        // Prefab Original Rotation
        if (no == -1)
        {
            _rotation = Quaternion.identity;
        }
        // Src Rotation
        if (no == 0)
        {
            _rotation = Src.transform.rotation;
        }
        // from Src to Obj
        if (no == 1)
        {
            _rotation = Quaternion.LookRotation((Obj.transform.position - Src.transform.position).normalized);
        }
        // Src Rotation + Vector3(factor[0], factor[1], factor[2])
        if (no == 2)
        {
            _rotation = Quaternion.Euler(Src.transform.eulerAngles + new Vector3(factor[0], factor[1], factor[2]));
        }
        // for Out of Src. factor[0]:InitObjX, factor[1]:InitObjY, factor[2]:InitObjZ
        if (no == 3)
        {
            _rotation = Quaternion.LookRotation((new Vector3(factor[0], factor[1], factor[2]) - Src.transform.position).normalized);
        }
        // Set Rotation Vector3
        if (no == 4)
        {
            _rotation = Quaternion.LookRotation(Vector3.RotateTowards(new Vector3(0, 0, 0), new Vector3(factor[0], factor[1], factor[2]), 10f, 10f));
        }

        return _rotation;
    }


    // BulletのPattern.csから呼び出し
    public void Move(GameObject Src, GameObject Obj, GameObject InitedObj, Vector3 initPos, Vector3 aimPos, int no, float[] factor)
    {
        // To forward (地域座標)
        if (no == 0) // factor[0] : Move Speed
        {
            Vector3 moveTo = InitedObj.transform.forward.normalized;
            InitedObj.transform.position = InitedObj.transform.position + moveTo * factor[0] * Time.deltaTime;
        }
        // From Shooter
        if (no == 1) // factor[0] : Move Speed
        {
            Vector3 moveTo = (InitedObj.transform.position - Src.transform.position).normalized;
            InitedObj.transform.position = InitedObj.transform.position + moveTo * factor[0] * Time.deltaTime;
        }
        // From Shooter To aimPos 
        if (no == 2) // factor[0] : Move Speed
        {
            Vector3 moveTo = (aimPos - Src.transform.position).normalized;
            InitedObj.transform.position = InitedObj.transform.position + moveTo * factor[0] * Time.deltaTime;
        }
        // From initPos To aimPos
        if (no == 3) // factor[0] : Move Speed
        {
            Vector3 moveTo = (aimPos - initPos).normalized;
            InitedObj.transform.position = InitedObj.transform.position + moveTo * factor[0] * Time.deltaTime;
        }
    }
    public void PlayerBulletMove(GameObject Src, GameObject Obj, GameObject InitedObj, Vector3 initPos, Vector3 aimPos, int no, float[] factor)
    {

        // To forward (地域座標)
        if (no == 0) // factor[0] : Move Speed
        {
            Vector3 moveTo = InitedObj.transform.forward.normalized;
            InitedObj.transform.position = InitedObj.transform.position + moveTo * factor[0] * Time.deltaTime;
        }
        // to Target
        if (no == 1) // factor[0] : Move Speed
        {
            Vector3 moveTo = (Obj.transform.position - InitedObj.transform.position).normalized;
            InitedObj.transform.position = InitedObj.transform.position + moveTo * factor[0] * Time.deltaTime;
        }

    }

}

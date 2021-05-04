using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //Transform Target[];

	private Rigidbody playerRigid;

	[SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashSpeed = 8f;
    private float faster = 1f;
	private Vector2 mPos;
	private Vector2 mPosDelta;
	private Vector2 mPos_;
	private float MouseRotateSpeed = 3f;
    private float CameraMaxDegree = 75;
    private float CameraMinDegree = 285;
    private float currentPoint=0f;
    private float countFaster=0f;

	private Quaternion tmpRotate;


	void Start () {
        playerRigid = gameObject.GetComponent<Rigidbody> ();
		tmpRotate = gameObject.transform.rotation;

	}

	void Update () {
		Move();
		FixForce();
	}

    private void Move() {
        bool focusingTarget = false;
        float moveX = 0f; float moveY = 0f; float moveZ = 0f;
        moveX += Input.GetAxisRaw("Horizontal");
        moveZ += Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl)) moveY += 1;
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl)) moveY += -1;
        if (Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Q))
        {
            if(moveX!=1) moveX += 1;
            focusingTarget = true;
            GameObject[] TargetListA = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] TargetListB = GameObject.FindGameObjectsWithTag("Boss");
            GameObject Target;
            if (TargetListA.Length == 0 && TargetListB.Length == 0) focusingTarget = false;
            else
            {
                if (TargetListA.Length != 0) Target = TargetListA[0];
                else Target = TargetListB[0];
                for (int i = 0; i < TargetListA.Length; i++)
                {
                    if (Vector3.Distance(transform.position, Target.transform.position) > Vector3.Distance(transform.position, TargetListA[i].transform.position))
                        Target = TargetListA[i];
                }
                for (int i = 0; i < TargetListB.Length; i++)
                {
                    if (Vector3.Distance(transform.position, Target.transform.position) > Vector3.Distance(transform.position, TargetListB[i].transform.position))
                        Target = TargetListB[i];
                }
                transform.LookAt(Target.transform);
                tmpRotate = transform.rotation;
            }
        }
        if (Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))
        {
            if (moveX != -1) moveX += -1;
            focusingTarget = true;
            GameObject[] TargetListA = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] TargetListB = GameObject.FindGameObjectsWithTag("Boss");
            GameObject Target;
            if (TargetListA.Length == 0 && TargetListB.Length == 0) focusingTarget = false;
            else
            {
                if (TargetListA.Length != 0) Target = TargetListA[0];
                else Target = TargetListB[0];
                for (int i = 0; i < TargetListA.Length; i++)
                {
                    if (Vector3.Distance(transform.position, Target.transform.position) > Vector3.Distance(transform.position, TargetListA[i].transform.position))
                        Target = TargetListA[i];
                }
                for (int i = 0; i < TargetListB.Length; i++)
                {
                    if (Vector3.Distance(transform.position, Target.transform.position) > Vector3.Distance(transform.position, TargetListB[i].transform.position))
                        Target = TargetListB[i];
                }
                transform.LookAt(Target.transform);
                tmpRotate = transform.rotation;
            }
        }

        //Dash
        if (GameObject.Find("DashPointPanel")!=null) currentPoint = GameObject.Find("DashPointPanel").GetComponent<DashPointBar>().currentPoint;
        if ((((moveX != 0) || (moveY != 0) || (moveZ != 0)) && Input.GetKeyDown(KeyCode.Space))&&currentPoint>=30&&!GameManager.isPause)
        {
            GameObject.Find("DashPointPanel").GetComponent<DashPointBar>().currentPoint -=30;
            faster = dashSpeed;
        }
        
        Vector3 move = (transform.right * moveX + transform.up * moveY + transform.forward * moveZ).normalized*moveSpeed*faster;
        playerRigid.MovePosition (transform.position + move * Time.deltaTime);
        //playerRigid.velocity = Vector3.Lerp(playerRigid.velocity, move, Time.deltaTime);
        //playerRigid.AddExplosionForce(moveSpeed * faster, move, 1f);
        //move *= Time.deltaTime * 75f;
        //transform.position += move;
        

        if (faster != 1f)
        {
            countFaster+=Time.deltaTime;
        }
        //Dash();
        if(countFaster > 0.25f)
        {
            faster = 1f;
            countFaster = 0f;
        }

        if (!(Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Q)) && !(Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E)) && !focusingTarget)
            Rotate();
    }

	private void Rotate()
	{
        transform.rotation = tmpRotate;
        transform.Rotate(0, Input.GetAxisRaw ("Mouse X") * MouseRotateSpeed,0);
        transform.Rotate(-Input.GetAxisRaw ("Mouse Y") * MouseRotateSpeed,0,0);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);

		if (transform.localEulerAngles.x > CameraMaxDegree && transform.localEulerAngles.x<=90)
		{
            transform.localEulerAngles = new Vector3(CameraMaxDegree, transform.localEulerAngles.y, transform.localEulerAngles.z);
		}
		if (transform.localEulerAngles.x < CameraMinDegree && transform.localEulerAngles.x>270)
		{
            transform.localEulerAngles = new Vector3(CameraMinDegree, transform.localEulerAngles.y, transform.localEulerAngles.z);
		}
        tmpRotate = transform.rotation;

	}

	private void FixForce(){
		playerRigid.velocity = new Vector3 (0, 0, 0);
		playerRigid.angularVelocity = new Vector3 (0, 0, 0);
	}
}

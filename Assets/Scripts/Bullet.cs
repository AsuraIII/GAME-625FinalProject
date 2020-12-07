using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float ShotSpeed = 0.5f;
    private float time;
    public Transform pointA;
    public Transform pointB;
    public float g = -5.0f;

    private Vector3 speed;
    private Vector3 Gravity;
    private Vector3 currentAngle;

    private Rigidbody2D _mRigid;

    private float pauseTime;
    private float timer;
    private float dTime = 0;

    public int damage = 1;


    public static event Action<Bullet> OnBulletHitted;
    void Start()
    {
        _mRigid = this.GetComponent<Rigidbody2D>();

        InitParabola();
    }

    public void InitParabola()
    {
        dTime = 0;
        pointA = this.transform;
        transform.position = pointA.position;
        pointB = Player._instance.transform;
        time = Vector3.Distance(pointA.position, pointB.position) / ShotSpeed;

        speed = new Vector3((pointB.position.x - pointA.position.x) / time,
            (pointB.position.y - pointA.position.y) / time - 0.5f * g * time, (pointB.position.z - pointA.position.z) / time);
        Gravity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Gravity.y = g * (dTime += Time.fixedDeltaTime);//v=at

        //transform.position += (speed + Gravity) * Time.fixedDeltaTime;
        _mRigid.velocity = speed + Gravity;
        // currentAngle.z = Mathf.Atan((speed.y + Gravity.y) / speed.x) * Mathf.Rad2Deg;
        //_mRigid.angularVelocity = currentAngle.z;


        //transform.eulerAngles = currentAngle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            speed = Vector3.zero;
            Gravity = Vector3.zero;
            _mRigid.velocity = Vector3.zero;
            this.transform.position = pointA.position;
            ObjectPooler._instance.ReturnToPool(ObjectType.Bullet, this.gameObject);
            
        }

        if (collision.tag == "Player")
        {
            Player._instance.BulletHitted(this);
        }
    }



    private void OnEnable()
    {
        InitParabola();
    }
}

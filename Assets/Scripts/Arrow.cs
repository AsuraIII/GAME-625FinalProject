using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_target;

    private Rigidbody2D m_rb;
    private float m_TimeInTheAir = 1.5f;
    private float ArrowMinSpeed = 300f;
    private float ArrowMaxSpeed = 600f;

    [SerializeField]
    private int damage=1;

    private Quaternion originalRotation;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        //m_rb.velocity = CalculateVelocity(m_target, m_TimeInTheAir);
        originalRotation = transform.rotation;
        InitStatus();
    }

    void Update()
    {
        UpdateAngle();
    }

    Vector2 CalculateVelocity(Vector3 target, float time)
    {
        Vector3 distance = target - this.transform.position;

        float distanceX = distance.x;
        float distanceY = distance.y;

        float Vx = distanceX / time;
        float Vy = distanceY / time + (0.5f * Mathf.Abs(Physics.gravity.y) * time);

        return new Vector2(Vx, Vy);
    }

    void UpdateAngle()
    {
        float angle = Mathf.Atan2(m_rb.velocity.y, m_rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnEnable()
    {
        InitStatus();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager._instance.PlayerhittedSound();
            GameManager._instance.PlayerHealth -= 1;
        }
        if (collision.tag == "Ground")
        {
            ObjectPooler._instance.ReturnToPool(ObjectType.Arrow,this.gameObject);
        }
    }

    private void InitStatus()
    {
        transform.rotation = originalRotation;
        if (m_rb)
        {
            m_rb.velocity = Vector2.zero;
            m_rb.AddForce(Vector2.left * RandomForce());
        }
    }

    private float RandomForce()
    {
        return Random.Range(ArrowMinSpeed, ArrowMaxSpeed);
    }
}

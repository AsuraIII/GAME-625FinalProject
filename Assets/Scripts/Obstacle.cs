using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;

    public static event Action<Obstacle> OnObstacleHitted;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player._instance.ObstacleHitted(this);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.tag == "Player")
    //    {
    //        if (OnObstacleHitted != null)
    //        {
    //            OnObstacleHitted(this);
    //        }
    //    }
    //}
}

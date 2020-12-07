using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    private int point = 1;

    //Coin Point
    public int Point { get => point; }

    public static event Action<Coin> OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("ccc");
            //if (OnCoinCollected != null)
            //{
            //    OnCoinCollected(this);
            //}
            Player._instance.CoinCollectedAchievement(this);
            //SoundManager._instance.PlayerTriggerCoinSound();
            //Destroy(gameObject);
            //GameManager._instance.CoinNum += Point;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathZone : MonoBehaviour
{
    private int damage = 1;

    //Coin Point
    public int Damage { get => damage; }

    public static event Action<DeathZone> OnDeathZoneHitted;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player._instance.DeathZoneHitted(this);
        }
    }
}

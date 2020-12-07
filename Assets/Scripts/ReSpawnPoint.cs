using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawnPoint : MonoBehaviour
{
    public Transform spawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player._instance.respawnPoint = spawnPoint;
        }
    }
}

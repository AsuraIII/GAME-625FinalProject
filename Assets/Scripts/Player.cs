using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player _instance;

    public Transform respawnPoint;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        //Bullet.OnBulletHitted += BulletHitted;
        //DeathZone.OnDeathZoneHitted += DeathZoneHitted;
       // Obstacle.OnObstacleHitted += ObstacleHitted;
       // Coin.OnCoinCollected += CoinCollectedAchievement;
    }

    public void BulletHitted(Bullet bullet)
    {
        ObjectPooler._instance.ReturnToPool(ObjectType.Bullet, bullet.gameObject);
        GameManager._instance.PlayerHealth -= bullet.damage;
        SoundManager._instance.PlayerhittedSound();
    }




    public void CoinCollectedAchievement(Coin coin)
    {
        SoundManager._instance.PlayerTriggerCoinSound();
        Destroy(coin.gameObject);
        GameManager._instance.CoinNum += coin.Point;
        Debug.Log(GameManager._instance.CoinNum);
    }

    public void DeathZoneHitted(DeathZone deathZone)
    {
        SoundManager._instance.PlayerhittedSound();
        GameManager._instance.PlayerHealth -= deathZone.Damage;
        //Respawn();
        //Time.timeScale = 0.1f;
        if (GetComponent<PlayerRunandJump>())
        {
            GetComponent<PlayerRunandJump>().canMove = false;
        }
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (GameManager._instance.PlayerHealth > 0)
        {
            Invoke("Respawn", 1.0f);
        }
    }

    public void ObstacleHitted(Obstacle obstacle)
    {
        SoundManager._instance.PlayerhittedSound();
        GameManager._instance.PlayerHealth -= obstacle.damage;
    }

    public void Respawn()
    {
        //Time.timeScale = 1.0f;
        this.transform.position = respawnPoint.position;
        GetComponent<PlayerRunandJump>().canMove = true;
    }

    public void ReSpawnGame()
    {
        GetComponent<PlayerRunandJump>().canMove = true;
        //GameManager._instance.InitialGameStatus();
        //InitialGameStatus();
    }



}

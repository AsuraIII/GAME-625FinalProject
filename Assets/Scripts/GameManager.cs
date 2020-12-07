using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static int playerHealth = 5;

    static int coinNum = 0;

    private int initHealth = 5;

    private int initCoin = 0;

    public static GameManager _instance;



    private void Awake()
    {
        //if (_instance == null)
        //{
        //    _instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

    }

    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitialUI();

    }

    private void OnEnable()
    {
        //InitialUI();
    }

    public int CoinNum
    {
        get { return coinNum; }
        set
        {
            coinNum = value;
            UIManager._instance.ChangeCoinNum(coinNum);
        }
    }

    public int PlayerHealth
    {
        get { return playerHealth; }
        set
        {
            playerHealth = value;
            if (playerHealth <= 0)
            {
                Player._instance.GetComponent<PlayerRunandJump>().canMove = false;
                StartCoroutine(Respawn(1.0f));

            }
            UIManager._instance.ChangeHealth(playerHealth);
        }
    }

    IEnumerator Respawn(float time)
    {
        yield return new WaitForSeconds(time);
        //Player._instance.Respawn();
        InitialGameStatus();
        LevelLoader._instance.LoadFirstLevel();
        //InitialPlayerStatus();
    }

    public void InitialUI()
    {
        Debug.Log(playerHealth);
        UIManager._instance.ChangeHealth(playerHealth);
        UIManager._instance.ChangeCoinNum(coinNum);
    }

    public void InitialPlayerStatus()
    {
        playerHealth = initHealth;
        //coinNum = initCoin;
        UIManager._instance.ChangeHealth(playerHealth);
        //UIManager._instance.ChangeCoinNum(coinNum);
    }

    public void InitialGameStatus()
    {
        playerHealth = initHealth;
        coinNum = initCoin;
        UIManager._instance.ChangeHealth(playerHealth);
        UIManager._instance.ChangeCoinNum(coinNum);
    }
}

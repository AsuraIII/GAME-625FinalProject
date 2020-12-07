using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriger : MonoBehaviour
{
    public Animator animator;
    public int coinNeeded = 4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (CheckEnoughCoin(coinNeeded))
            {
                animator.SetTrigger("Open");
            }
            else if (!CheckEnoughCoin(coinNeeded))
            {
                LevelLoader._instance.LoadFirstLevel();
                GameManager._instance.InitialGameStatus();
            }
        }
    }

    private bool CheckEnoughCoin(int coinNeeded)
    {
        return GameManager._instance.CoinNum >= coinNeeded;
    }
}

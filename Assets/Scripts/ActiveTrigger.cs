using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTrigger : MonoBehaviour
{
    public bool isTrigger;
    public GameObject gameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTrigger = true;
            if (gameObject&&gameObject.GetComponent<Animator>())
            {
                gameObject.GetComponent<Animator>().SetTrigger("IsHelp");
            }

        }
    }
}

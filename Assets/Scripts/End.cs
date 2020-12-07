using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private NPC npc;
    private void Start()
    {
        npc = GetComponent<NPC>();
    }

    private void Update()
    {
        if (npc.sentences.Count <= 0)
        {
            UIManager._instance.ShowEndMessage();
            Time.timeScale = 0.3f;
        }
    }
}

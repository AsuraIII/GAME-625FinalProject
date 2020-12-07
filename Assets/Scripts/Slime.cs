using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Slime : Enemy
{
    public bool active = false;
    public float spawnTime = 0.5f;
    public ActiveTrigger trigger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.isTrigger && !active)
        {
            active = true;
            StartCoroutine(SpawnBullet(spawnTime));
        }
    }

    private IEnumerator SpawnBullet(float time)
    {
        while (true)
        {
            ObjectPooler._instance.SpawnFromPool(ObjectType.Bullet, new UnityEngine.Vector2(this.transform.position.x, this.transform.position.y + 0.4f));
            yield return new WaitForSeconds(time);
        }
    }
}

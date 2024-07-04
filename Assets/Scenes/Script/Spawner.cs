using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoint;

    float timer;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameManager.instance.pool.Get(1);
        }
    }
}

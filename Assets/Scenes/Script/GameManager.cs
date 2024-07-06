using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public static GameManager instance;
    public PoolManager pool;


    public float gameTime;
    public float maxGameTime = 6 * 60f;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        gameTime += Time.deltaTime;
    }
}

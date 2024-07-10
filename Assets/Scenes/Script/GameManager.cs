using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("# Game Control")]
    public Player player;
    public static GameManager instance;
    public PoolManager pool;

    [Header("# Player Info")]
    public int level;
    public int kill;
    public int exp;
    public int health;
    public int maxHealth;
    public int[] nextExp = { 10, 30, 60, 100, 150, 210, 280, 360, 450, 600 };

    [Header("# Game Object")]
    public float gameTime;
    public float maxGameTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        gameTime += Time.deltaTime;
        if(gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++;
        if(exp > nextExp[level])
        {
            exp = 0;
            level++;
        }
    }
}

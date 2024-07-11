using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("# Game Control")]
    public bool isLive;
    public Player player;
    public static GameManager instance;
    public PoolManager pool;

    [Header("# Player Info")]
    public int playerId;
    public int level;
    public int kill;
    public int exp;
    public float health;
    public float maxHealth;
    public int[] nextExp = { 10, 30, 60, 100, 150, 210, 280, 360, 450, 600 };

    [Header("# Game Object")]
    public float gameTime;
    public float maxGameTime;
    public LevelUp uiLevelUp;
    public Result uiResult;
    public GameObject enemyCleaner;

    private void Awake()
    {
        instance = this;
    }

    public void GameStart(int id)
    {
        playerId = id;
        isLive = true;
        health = maxHealth;
        player.gameObject.SetActive(true);
        uiLevelUp.Select(id % 2);
        Resume();
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }
    public void GameVictory()
    {
        StartCoroutine(GameVictoryRoutine());
    }

    IEnumerator GameVictoryRoutine()
    {
        isLive = false;
        enemyCleaner.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        uiResult.gameObject.SetActive(true);
        uiResult.Win();
        Stop();
    }
    IEnumerator GameOverRoutine()
    {
        isLive = false;
        yield return new WaitForSeconds(0.5f);
        uiResult.gameObject.SetActive(true);
        uiResult.Lose();
        Stop();
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if(!isLive) { return; } 
        gameTime += Time.deltaTime;
        if(gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
            GameVictory();
        }
    }

    public void GetExp()
    {
        if (!isLive) { return; }
        exp+= 30;
        if(exp > nextExp[Mathf.Min(level,nextExp.Length-1)])
        {
            exp = 0;
            level++;
            uiLevelUp.Show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public static GameManager instance;
    public PoolManager pool;
    private void Awake()
    {
        instance = this;
    }
}

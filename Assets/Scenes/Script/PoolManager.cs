using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //프리팹들을 보관할 변수

    public GameObject[] prefabs;

    // 풀 담당을 하는 리스트들
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }


    public GameObject Get(int index)
    {
        GameObject select = null;
        // 선택한 풀에 놀고 있는 게임 오브젝트 접근
        foreach(GameObject item in pools[index])
        {
            // 발견 시 select에 할당
            if (!item.activeSelf) { 
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 없다면
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }


        return select;
    }
}

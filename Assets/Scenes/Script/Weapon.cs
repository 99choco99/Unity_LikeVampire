using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;


    float timer;
    Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    private void Start()
    {
        Init();
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count = count;

        if(id == 0)
        {
            Batch();
        }
    }


    private void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            case 1:
                break;
            default:
                timer += Time.deltaTime;

                if(timer > speed)
                {
                    timer = 0f;
                    Fire();
                }
                break;
        }
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 150;
                Batch();
                break;
            case 1:
                speed = 0.3f;
                break;
            default:
                break;

        }
    }


    void Batch()
    {
        for(int i = 0; i< count; i++)
        {
            Transform bullet;
            if (i < transform.childCount)
            {
                bullet = transform.GetChild(i);
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * i / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f,Space.World);

            bullet.GetComponent<Bullet>().Init(damage, -1);  // - 1 is Infinity Per.
        }
    }

    void Fire()
    {
        if (!player.scanner.nearestTarget) { return; }
        else
        {
            Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
            bullet.position = transform.position;
        }
    }
}

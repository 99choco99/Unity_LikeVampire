using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public Scanner scanner;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    public float speed;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }


    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }


    void FixedUpdate()
    {

        //3. 위치 이동
        Vector2 nextVec = inputVec.normalized * speed *Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameManager.instance.health -= 1;

            if(GameManager.instance.health < 0)
            {
                Debug.Log("게임 끝");
            }
        }
    }
}

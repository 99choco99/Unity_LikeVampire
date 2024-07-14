using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public Scanner scanner;
    public RuntimeAnimatorController[] animCon;
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

    private void OnEnable()
    {
        speed *= Character.speed;
        anim.runtimeAnimatorController = animCon[GameManager.instance.playerId];
    }


    void Update()
    {
        if (!GameManager.instance.isLive) { return; }
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }


    void FixedUpdate()
    {
        if (!GameManager.instance.isLive) { return; }
        //3. 위치 이동
        Vector2 nextVec = inputVec.normalized * speed *Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
    void LateUpdate()
    {
        if (!GameManager.instance.isLive) { return; }
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(!GameManager.instance.isLive) { return; }

        GameManager.instance.health -= 10 * Time.deltaTime;

        if(GameManager.instance.health <= 0)
        {
            for(int i = 2; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            anim.SetTrigger("Dead");

            GameManager.instance.GameOver();
        }
    }

}

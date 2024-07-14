using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Area"))
        {
            Vector3 playerPosition = GameManager.instance.player.transform.position;
            Vector3 MyPos = transform.position;


            switch (transform.tag)
            {
                case "Ground":
                    float diffx = playerPosition.x - MyPos.x;
                    float diffy = playerPosition.y - MyPos.y;

                    float dirX = diffx < 0 ? -1 : 1;
                    float dirY = diffy < 0 ? -1 : 1;

                    diffx = Mathf.Abs(diffx);
                    diffy = Mathf.Abs(diffy);
                    if (diffx > diffy)
                    {
                        transform.Translate(Vector3.right * dirX * 40);
                    }
                    else
                    {
                        transform.Translate(Vector3.up * dirY * 40);
                    }
                    break;
                case "Enemy":
                    if (coll.enabled)
                    {
                        Vector3 dist = playerPosition - MyPos;
                        Vector3 ran = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
                        transform.Translate(ran + dist * 2);
                    }
                    break;

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Area"))
        {
            Vector3 playerPosition = GameManager.instance.player.transform.position;
            Vector3 MyPos = transform.position;
            float diffx = Mathf.Abs(playerPosition.x - MyPos.x);
            float diffy = Mathf.Abs(playerPosition.y - MyPos.y);

            Vector3 playerDir = GameManager.instance.player.inputVec;
            float dirX = playerDir.x < 0 ? -1 : 1;
            float dirY = playerDir.y < 0 ? -1 : 1;


            switch (transform.tag)
            {
                case "Ground":
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
                    break;

            }
        }
    }
}

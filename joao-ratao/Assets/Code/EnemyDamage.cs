using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int dmg = 1;
    public CharacterHealth playerHp;
    public CharacterMovement player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.KBCounter = player.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                player.KnockFromRight = true;
            } else if (collision.transform.position.x > transform.position.x)
            {
                player.KnockFromRight = false;
            }
            playerHp.TakeDamage(dmg);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject whatHit = collision.gameObject;

        if (whatHit.CompareTag("Player")){
            whatHit.GetComponent<CharacterHealth>().TakeDamage(9999);
        } else if (whatHit.CompareTag("Enemy"))
        {
            Destroy(whatHit);
        }
    }
}

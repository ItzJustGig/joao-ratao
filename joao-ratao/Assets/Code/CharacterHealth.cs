using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int maxHp = 3;
    public int curHp;
    public float IFramesTimer = 0f;
    public float IFramesLenght = 2f;
    public Color color = Color.white;
    public Color defaultColor;
    public float respawnTime = 3f;
    public float respawnTimer = 0f;
    public bool isDead = false;
    public Transform spawn;

    void Start()
    {
        defaultColor = gameObject.GetComponent<SpriteRenderer>().color;
        curHp = maxHp;
    }

    private void Update()
    {
        if (IFramesTimer > 0f)
        {
            IFramesTimer -= Time.deltaTime;
        } else
        {
            if (gameObject.GetComponent<SpriteRenderer>().color != defaultColor)
                gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
        }

        if (respawnTimer >= 0)
        { 
            respawnTimer -= Time.deltaTime; 
        } else
        {
            if (isDead == true)
            {
                gameObject.GetComponent<CharacterMovement>().KBCounter = 0;
                isDead = false;
                curHp = maxHp;
                gameObject.GetComponent<Rigidbody2D>().simulated = true;
                gameObject.transform.position = spawn.transform.position;
                gameObject.GetComponent<Animator>().SetBool("Dead", false);
            }
        }
    }

    public void TakeDamage(int dmg)
    {
        if (IFramesTimer <= 0f) {
            curHp -= dmg;
            IFramesTimer = IFramesLenght;
            gameObject.GetComponent<SpriteRenderer>().color = color;
            if (curHp <= 0)
            {
                Death();
            } else
            {
                gameObject.GetComponent<Animator>().SetTrigger("Hit");
            }
        }
    }

    public void Death()
    {
        if (curHp <= 0) {
            respawnTimer = respawnTime;
            isDead = true;
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            gameObject.GetComponent<Animator>().SetBool("Dead", true);
        }
    }
}

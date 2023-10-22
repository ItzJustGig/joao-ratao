using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum Type { Points, Heal, Key, TriggerBoss }
    public Type type;
    public int value;
    public DoorManager doorManager;
    public CharacterHealth character;
    public Animator boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (type is not Type.Key && type is not Type.TriggerBoss)
            {
                if (CollectableCounter.Instance.AddCollectable(value, type))
                {
                    Destroy(gameObject);
                }
            }
            else if (type is Type.Key)
            {
                doorManager.Open();
                Destroy(gameObject);
            } else
            {
                doorManager.Close();
                character.spawn.transform.position = this.transform.position;
                boss.SetTrigger("Spawn");
                Destroy(gameObject);
            }
        }
    }
}

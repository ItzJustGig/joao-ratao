using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCounter : MonoBehaviour
{
    public static CollectableCounter Instance;
    public CharacterHealth character;
    public int curPoints = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    public bool AddCollectable(int value, Collectable.Type type)
    {
        switch (type)
        {
            case Collectable.Type.Heal:
                if (character.curHp < character.maxHp) 
                {
                    if (character.curHp + value <= character.maxHp)
                    {
                        character.curHp += value;
                    }
                    else
                    {
                        character.curHp = character.maxHp;
                    }
                } else
                {
                    return false;
                }
                
                break;
            case Collectable.Type.Points:
                curPoints += value;
                break;
            case Collectable.Type.Key:
                Debug.Log("!KEY!");
                break;
        }
        return true;
    }
}

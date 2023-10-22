using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    [ContextMenu("Open Door")]
    public void Open()
    {
        animator.SetTrigger("Open");
    }
    
    [ContextMenu("Close Door")]
    public void Close()
    {
        animator.SetTrigger("Close");
    }
}

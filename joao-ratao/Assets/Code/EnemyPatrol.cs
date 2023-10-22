using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public enum WhereIdle { Never, PointA, PointB }

    public GameObject pointA;
    public GameObject pointB;
    public float speed = 2f;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public WhereIdle whereIdle;
    //quantos ciclos completos ele faz antes d entrar em idle
    public int cicleIdle = 0;
    public int curCicles = 0;
    public float idleTime = 2;
    public float curIdleTime = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
    }

    void Update()
    {
        if (curIdleTime <= 0)
        { 
            anim.SetBool("isRunning", true);
            Vector2 point = currentPoint.position - transform.position;

            if (currentPoint == pointB.transform)
            {
                if (whereIdle is WhereIdle.PointA && curCicles >= cicleIdle)
                {
                    SetIdle();
                    rb.velocity = new Vector2(0, 0);
                } else
                {
                    rb.velocity = new Vector2(speed, 0);
                }
            }
            else
            {
                if (whereIdle is WhereIdle.PointB && curCicles >= cicleIdle)
                {
                    SetIdle();
                    rb.velocity = new Vector2(0, 0);
                }
                else
                {
                    rb.velocity = new Vector2(-speed, 0);
                }
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < .5f && currentPoint == pointB.transform)
            {
                Flip();
                currentPoint = pointA.transform;
                if (whereIdle is not WhereIdle.Never)
                    curCicles++;
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < .5f && currentPoint == pointA.transform)
            {
                Flip();
                currentPoint = pointB.transform;
            }
        } else
        {
            curIdleTime -= Time.deltaTime;
            anim.SetBool("isRunning", false);
        }
    }

    private void SetIdle()
    {
        curIdleTime = idleTime;
        curCicles = 0;
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, .5f);
        Gizmos.DrawWireSphere(pointB.transform.position, .5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);

    }
}

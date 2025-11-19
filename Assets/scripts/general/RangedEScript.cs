using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyScript : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject player;
    private float speed;

    [SerializeField] private float range = 10f;

    [SerializeField] bool inRange;

    [SerializeField] private float fireCD = 3;
    private float currentCd;

    void Start()
    {
        speed = GetComponent<EnemyStatusManager>().Speed;
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (projectilePrefab == null)
        {
            projectilePrefab = Resources.Load<GameObject>("ProjectilePrefab");
        }
        currentCd = fireCD;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;

        int playerLayer = LayerMask.GetMask("Player");

        RaycastHit2D hit = Physics2D.Raycast(
            origin: transform.position,
            direction: direction,
            distance: range,
            layerMask: playerLayer
        );

        inRange = hit.collider != null && hit.collider.CompareTag("Player");

        if (inRange || Vector2.Distance(player.transform.position,transform.position)<10f)
        {
            if (currentCd >= fireCD)
            {
                Shoot();
                currentCd = 0;
            }
            else
            {
                currentCd += Time.deltaTime;
            }
            
        }
        else 
        {
            Move();
        }
    }

    private void Move()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if(rb != null)
        {
            Vector2 next = Vector2.MoveTowards(rb.position,player.transform.position,speed*Time.deltaTime);
            rb.MovePosition(next);
        }

    }

    private void Shoot()
    {
        Instantiate(
            original: projectilePrefab,
            position: transform.position,
            rotation: transform.rotation);
    }

    private void OnDrawGizmosSelected()
    {

        if (inRange)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }


            Gizmos.DrawLine(from: transform.position, to: player.transform.position);
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMovement : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject playerPosition;
    public float speed = 0.75f;

    public float range = 10f;

    [SerializeField] bool inRange;

    public float fireCD = 3;

    void Start()
    {
        if (playerPosition == null)
        {
            playerPosition = GameObject.FindWithTag("Player");
        }

        if (projectilePrefab == null)
        {
            projectilePrefab = Resources.Load<GameObject>("ProjectilePrefab");
        }
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = ((Vector2)playerPosition.transform.position - (Vector2)transform.position).normalized;

        int playerLayer = LayerMask.GetMask("Player");

        RaycastHit2D hit = Physics2D.Raycast(
            origin: transform.position,
            direction: direction,
            distance: range,
            layerMask: playerLayer
        );

        inRange = hit.collider != null && hit.collider.CompareTag("Player");

        if (inRange)
        {
            if (fireCD >= 3)
            {
                Shoot();
                fireCD = 0;
            }
            else
            {
                fireCD += Time.deltaTime;
            }
            
        }
        else 
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(
        current: transform.position,
        target: playerPosition.transform.position,
        maxDistanceDelta: speed * Time.deltaTime);
    }

    private void Shoot()
    {
        Instantiate(
            original: projectilePrefab,
            position: transform.position,
            rotation: transform.rotation,
            parent: transform);
    }
}

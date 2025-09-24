using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnakMovement : MonoBehaviour
{
    public GameObject playerPosition;


    public float speed = 1f;

    [SerializeField] public int damage = 10;
    void Start()
    {
        if (playerPosition == null)
        {
            playerPosition = GameObject.FindWithTag("Player");
        }

    }
    // Update is called once per frame
    void Update()
        {
            transform.position = Vector2.MoveTowards(
                current: transform.position,
                target: playerPosition.transform.position,
                maxDistanceDelta: speed * Time.deltaTime);
        }
    }

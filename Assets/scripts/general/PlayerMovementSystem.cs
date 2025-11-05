using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{

    [SerializeField] private float speed = 1f;

    public float Speed { get => speed; set => speed = value; }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: Input.GetAxisRaw("Vertical"));

        if (input.sqrMagnitude > 1f)
        {
            input.Normalize();
        }

        Vector2 movement = input * speed * Time.deltaTime;
        transform.position = (Vector2)transform.position + movement;
        
    }
}

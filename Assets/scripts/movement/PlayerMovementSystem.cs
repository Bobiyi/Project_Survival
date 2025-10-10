using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{

    [SerializeField]private float speed = 1f;

    public float Speed { get => speed; set => speed = value; }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime,
                        transform.position.y + Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime);
    }


    



}

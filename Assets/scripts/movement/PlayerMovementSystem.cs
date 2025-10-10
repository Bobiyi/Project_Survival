using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{

    public float speed = 1f;


    // Update is called once per frame
    void Update()
    {
        transform.position =
            new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime,
                        transform.position.y + Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);

    }
}

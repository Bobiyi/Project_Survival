using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMovement : MonoBehaviour
{

    public GameObject player;

    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector2.MoveTowards(
            current: transform.position,
            target: player.transform.position,
            maxDistanceDelta: speed * Time.deltaTime);
    }
}

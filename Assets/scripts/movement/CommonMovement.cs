using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMovement : MonoBehaviour
{

    [SerializeField] private GameObject player;

    //[SerializeField] private PlayerManager playerScript;

    [SerializeField] private float speed = 1f;

    public float Speed { get => speed; set => speed = value; }

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            current: transform.position,
            target: player.transform.position,
            maxDistanceDelta: Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        } 
    }

}

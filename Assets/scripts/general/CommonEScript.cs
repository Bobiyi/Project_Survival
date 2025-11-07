using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CommonMovement : MonoBehaviour
{

    [SerializeField] private GameObject player;

    //[SerializeField] private PlayerManager playerScript;

    private float speed;


    public float Speed { get => speed; set => speed = value; }

    void Start()
    {
        speed = GetComponent<EnemyStatusManager>().Speed;

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

    
   

        
}

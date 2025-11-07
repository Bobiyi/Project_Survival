using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CommonMovement : MonoBehaviour
{

    [SerializeField] private GameObject player;

    [SerializeField] private PlayerManager playerScript;

    [SerializeField] private float speed = 1f;

    [SerializeField] private float health = 50f;

    [SerializeField] private GameObject XPpref;

    public float Speed { get => speed; set => speed = value; }
    public float Health { get => health; set => health = value; }

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (XPpref==null)
        {
            XPpref = Resources.Load<GameObject>("xp");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            current: transform.position,
            target: player.transform.position,
            maxDistanceDelta: Speed * Time.deltaTime);

        if (Health <= 0f)
        {
            Destroy(gameObject);

            Instantiate(XPpref,
            position: new Vector2(transform.position.x, transform.position.y - 0.75f),
            rotation: Quaternion.identity);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
            playerScript = collision.gameObject.GetComponent<PlayerManager>();

            playerScript.TakeDamage(10f);


            
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class ProjectileMovement : MonoBehaviour
{
    public Transform LatestPosition;

    public float speed = 1f;

    private PlayerManager PlayerManagerScript;

    [SerializeField] private Vector2 MovementDirection;
    [SerializeField] private float distanceToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (LatestPosition == null) 
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                LatestPosition = player.transform;
            }
        }

        if (PlayerManagerScript == null)
        {
            PlayerManagerScript = Resources.Load<PlayerManager>("PlayerManager");
        }

        if (LatestPosition != null) 
        { 

            MovementDirection = (LatestPosition.position - transform.position).normalized;

            
            Vector2 direction = (LatestPosition.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            //thx Copilot
        }
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(
            a: transform.position,
            b: LatestPosition.position
            );

        if (distanceToPlayer > 25f)
        {
            Destroy(gameObject);

        }

        transform.position += (Vector3)(MovementDirection * speed * Time.deltaTime);
    }
}

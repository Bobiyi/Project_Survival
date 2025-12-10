using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWandProjectileScript : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private MagicWandScript magicWandScript;

    
    [SerializeField] private float damage;
    [SerializeField] private float knockback;
    [SerializeField] private float speed;

    private Vector2 MovementDirection;
    private float distanceToPlayer;
    [SerializeField] private float deadZone=30f;
    private GameObject player;



    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");



        magicWandScript = player.GetComponentInChildren<MagicWandScript>();
        damage = magicWandScript.Damage;
        knockback = magicWandScript.Knockback;

        target = GetClosestEnemy(enemies: GameObject.FindGameObjectsWithTag("Enemy"));


            MovementDirection = (target.position - transform.position).normalized;


            Vector2 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Update is called once per frame
    void Update()
    {

        distanceToPlayer = Vector2.Distance(a:transform.position,b:player.transform.position);

        if (distanceToPlayer >= deadZone)
        {
            Destroy(gameObject);
        }

        transform.position += (Vector3)(MovementDirection * speed * Time.deltaTime);

    }

    private Transform GetClosestEnemy(GameObject[] enemies)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget.transform;
    }
}

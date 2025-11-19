using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private EnemyStatusManager status;
    [SerializeField] private float fallbackSpeed = 1f;
    [Tooltip("If Rigidbody2D velocity magnitude exceeds this value, AI movement is skipped so knockback can play.")]
    [SerializeField] private float ignoreVelocityThreshold = 0.1f;

    private Rigidbody2D rb;

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();

        if (status == null) status = GetComponent<EnemyStatusManager>();

        if (player == null)
        {
            var pgo = GameObject.FindWithTag("Player");

            if (pgo != null) player = pgo;
        }

    }

    void FixedUpdate()
    {
        if (player == null) return;

        float currentSpeed = (status != null) ? status.Speed : fallbackSpeed;

        //nincs rigidbody -> Vector 2 fallback
        if(rb == null)
        {
            Vector2 next = Vector2.MoveTowards(
                current:(Vector2)transform.position,
                target: (Vector2)player.transform.position,
                currentSpeed * Time.fixedDeltaTime);

            transform.position = next;
            return;
        }


        //ha a rigidbodynak jelenleg nagy velocityja van -> nem kell updatelni
        if (rb.velocity.sqrMagnitude > ignoreVelocityThreshold * ignoreVelocityThreshold) return;

        Vector2 nextPos = Vector2.MoveTowards(rb.position, (Vector2)player.transform.position, currentSpeed * Time.fixedDeltaTime);
        rb.MovePosition(nextPos);
    }

    public void DisableMovement(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(DisableMovementRoutine(duration));
    }

    private IEnumerator DisableMovementRoutine(float duration)
    {
        enabled = false;

        yield return new WaitForSeconds(duration);

        enabled = true;
    } 




}

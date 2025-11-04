using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSpawnerScript : MonoBehaviour
{
    [Header("Prefab / Timing")]
    [SerializeField] private GameObject Enemy;
    [SerializeField] private int spawnTime = 3;

    [Header("Spawn around player")]
    [SerializeField] private Transform player;
    [SerializeField] private float spawnDistance = 5f;

    void Start()
    {
        if (player == null)
        {
            var pgo = GameObject.FindWithTag("Player");
            if (pgo != null) player = pgo.transform;
        }

        InvokeRepeating(methodName: "spawn", time:0f, repeatRate: spawnTime);
    }

    private void spawn()
    {
        if (Enemy == null)
        {
            Debug.LogWarning("[EnemySpawnerScript] Enemy is not assigned.");
            return;
        }

        Vector2 center = player != null ? (Vector2)player.position : (Vector2)transform.position;

        float angle = Random.Range(0f, Mathf.PI * 2f);
        Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnDistance;
        Vector2 spawnPos = center + offset;

        Instantiate(Enemy, spawnPos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = player != null ? player.position : transform.position;
        Gizmos.DrawWireSphere(center, spawnDistance);
    }
}
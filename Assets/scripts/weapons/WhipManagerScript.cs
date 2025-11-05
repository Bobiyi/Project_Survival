using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipManager : MonoBehaviour
{
    [SerializeField] private GameObject whipProjectile;
    [SerializeField] private float projectileInbetween;
    [SerializeField] private float burstInbetween;
    [SerializeField] private float projectileCount;

    private float currentProjectileInbetween;
    private float currentBurstInbetween;
    private bool burstOngoing;
    void Start()
    {
        currentProjectileInbetween = projectileInbetween;
        currentBurstInbetween = burstInbetween;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBurstInbetween >= burstInbetween && !burstOngoing) 
        {
            Burst();
        }
        else
        {
            currentBurstInbetween += Time.deltaTime;
        }

    }

    void Burst()
    {
        burstOngoing = true;

        for (int i = 0; i <= projectileCount; i++)
        {
            Instantiate(
                original: whipProjectile,
                position: transform.position,
                rotation: Quaternion.identity
                );
        }

        burstOngoing = false;
    }

}

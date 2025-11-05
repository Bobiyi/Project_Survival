using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipManager : MonoBehaviour
{
    [SerializeField] private GameObject whipProjectile;
    [SerializeField] private float projectileInbetween;
    [SerializeField] private float burstInbetween;
    [SerializeField] private float projectileCount;
    [SerializeField] private GameObject character;

    private float currentProjectileInbetween;
    private float currentBurstInbetween;
    private bool burstOngoing;
    private int alreadyHit;
    private float xOffset;
    private float yOffset;
    private bool mainCharacterFLipped;

    void Start()
    {
        currentProjectileInbetween = projectileInbetween;
        currentBurstInbetween = burstInbetween;
        alreadyHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //burst countdown
        if (currentBurstInbetween >= burstInbetween && !burstOngoing) 
        {
           burstOngoing = true;
           currentBurstInbetween = 0f;
        }
        else
        {
            currentBurstInbetween += Time.deltaTime;
        }


        //burstot abba hagyha ha x projectilet kidob
        if(alreadyHit >= projectileCount)
        {
            burstOngoing = false;
            alreadyHit = 0;
        }

        //maga a burst
        if (burstOngoing && currentProjectileInbetween >= projectileInbetween)
        {
            Hit();
            alreadyHit++;
            currentProjectileInbetween = 0f;
        }
        else
        {
            currentProjectileInbetween += Time.deltaTime;
        }
    }

    void Hit()
    {
        OffsetCalculator();
        Instantiate(
        original: whipProjectile,
        position: new Vector3(transform.position.x + xOffset, transform.position.y + yOffset),
        rotation: Quaternion.identity
        );
    }

    void OffsetCalculator()
    {
        //kari flippelt -e?
        mainCharacterFLipped = character.GetComponentInChildren<PlayerSpriteScript>().getIsFlipped();

        yOffset = alreadyHit * 0.7f;
        xOffset = 2f;

        //arra üt ammerre néz a kari
        if (mainCharacterFLipped)
        {
            xOffset *= -1;
        }
        //hitenkénti alternálás
        if(alreadyHit % 2 != 0)
        {
            xOffset *= -1;
        }
    }
    
}

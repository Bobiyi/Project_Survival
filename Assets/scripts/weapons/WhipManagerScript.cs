using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipManager : MonoBehaviour, weapon
{
    [SerializeField] private float baseDmg;
    [SerializeField] private float baseProjectileCount;
    [SerializeField] private float baseSizeMult;


    [SerializeField] private GameObject whipProjectile;
    [SerializeField] private float projectileInbetween;
    [SerializeField] private float burstInbetween;
    private float currDmg;
    private float projectileCount;
    private float currSizeMult;
    [SerializeField] private GameObject character;
    [SerializeField] private float level;
    [SerializeField] private float knockback;


    private float currentProjectileInbetween;
    private float currentBurstInbetween;
    private bool burstOngoing;
    private int alreadyHit;
    private float xOffset;
    private float yOffset;
    private bool mainCharacterFLipped;

    public float BaseSizeMult { get => baseSizeMult; set => baseSizeMult = value; }
    public float BaseDmg { get => baseDmg; set => baseDmg = value; }
    public float CurrDmg { get => currDmg; set => currDmg = value; }
    public float CurrSizeMult { get => currSizeMult; set => currSizeMult = value; }

    void Start()
    {
        currSizeMult = baseSizeMult;
        currDmg = baseDmg;
        projectileCount = baseProjectileCount;
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

        bool spriteflipped = false;
        if (xOffset < 0)
        {
            spriteflipped = true;
        }
        var whipInstance =Instantiate(
        original: whipProjectile,
        position: new Vector3(transform.position.x + xOffset, transform.position.y + yOffset),
        rotation: Quaternion.identity
        );

        var sr = whipInstance.GetComponent<SpriteRenderer>();
        if (sr != null) sr.flipX = spriteflipped;

        var ws = whipInstance.GetComponent<whipScript>();
        if (ws != null) ws.setKnockback(knockback);
        
    }

    void OffsetCalculator()
    {
        //kari flippelt -e?
        mainCharacterFLipped = character.GetComponentInChildren<PlayerSpriteScript>().getIsFlipped();

        yOffset = alreadyHit * 0.7f + 1.5f;
        xOffset = 2.3f;

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

    public void lvlup(int lvls)
    {
        float startinglevel = level;
        for (;level <= startinglevel + lvls;level++)
        {
            switch (level)
            {
                case 2: projectileCount++   ; break;
                case 3: currDmg += 5; break;
                case 4: currSizeMult *= 1.10f; currDmg+=5 ; break;
                case 5: currDmg += 5; break;
                case 6: currSizeMult *= 1.10f; currDmg += 5; break;
                case 7: currDmg += 5; break;
                case 8: currDmg += 5; break;     
            }
       }
    }
}

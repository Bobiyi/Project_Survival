using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicScript : MonoBehaviour, weapon
{
    private float level;
    [SerializeField] private float baseDamage;
    [SerializeField] private float baseAreaMultiplier;
    [SerializeField] private float baseDmgInbetween;

     private float damage;
    [SerializeField] private float baseArea;
     private float areaMultiplier;
     private float dmgInbetweenTimer;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private CircleCollider2D Collider;
    [SerializeField] private Animator animator;
    public float GetDamage { get => damage; set => damage = value; }
    public float DmgInbetweenTimer { get => dmgInbetweenTimer; set => dmgInbetweenTimer = value; }

    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        damage = baseDamage;
        dmgInbetweenTimer = baseDmgInbetween;
        areaMultiplier = baseAreaMultiplier;
        Collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        Collider.radius = 0;
        sprite.transform.localScale = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        




    }

    void AreaUpdate()
    {
        
        Collider.radius = (baseArea * areaMultiplier)*0.16f;
        sprite.transform.localScale = new Vector2(baseArea*4*areaMultiplier, baseArea*4*areaMultiplier);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy")){
            EnemyStatusManager enemyScript = collision.gameObject.GetComponent<EnemyStatusManager>();
            if (enemyScript.GarlicHasFirstHit)
            {
                enemyScript.Damaged(damage, 0f);
                enemyScript.GarlicHasFirstHit = false;
                enemyScript.GarlicCurrentTime = 0;
            }
            if (enemyScript.GarlicCurrentTime >= enemyScript.GarlicTimer)
            {
                enemyScript.Damaged(damage, 0f);
                enemyScript.GarlicCurrentTime = 0;

            }
        }
       
    }

    public void lvlup(int lvls)
    {
        float startinglevel = level;
        for (; level <= startinglevel + lvls; level++)
        {
            switch (level)
            {
                case 1: enabled = true; damage = baseDamage; dmgInbetweenTimer = baseDmgInbetween;  areaMultiplier = baseAreaMultiplier; break;
                case 2: areaMultiplier *= 1.4f; damage+=2 ; break;
                case 3: damage += 1; dmgInbetweenTimer-=0.1f ; break;
                case 4: areaMultiplier *= 1.2f; damage+=1 ; break;
                case 5: damage += 2; dmgInbetweenTimer -= 0.1f; break;
                case 6: areaMultiplier *= 1.2f; damage += 1; break;
                case 7: damage += 1; dmgInbetweenTimer -= 0.1f; break;
                case 8: areaMultiplier *= 1.2f; damage += 1; break;
            }
        }
        AreaUpdate();
    }
}

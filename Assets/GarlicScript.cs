using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class GarlicScript : MonoBehaviour
{
    [SerializeField] private bool Enabled;
    [SerializeField] private float damage;
    [SerializeField] private float baseArea;
    [SerializeField] private float areaMultiplier;
    [SerializeField] private float dmgInbetweenTimer;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private CircleCollider2D Collider;

    private float currentDmgInbetweenTimer;
    // Start is called before the first frame update
    void Start()
    {
        Enabled = true;
        Collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enabled) { 
            currentDmgInbetweenTimer += Time.deltaTime;
            AreaUpdate();
        }
        else
        {
            Collider.radius = 0;
            sprite.transform.localScale = new Vector2(0,0);
        }

        

    }

    void AreaUpdate()
    {
        
        Collider.radius = baseArea/8 * areaMultiplier;
        sprite.transform.localScale = new Vector2(baseArea*2*areaMultiplier, baseArea*2*areaMultiplier);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Damage(collision);
        }
    }

    void Damage(Collider2D collision)
    {
        bool hasHitAlready = collision.gameObject.GetComponent<EnemyStatusManager>().GarlicHasFirstHit;
        //ha first time hit
        if (hasHitAlready)
        {
            if (currentDmgInbetweenTimer >= dmgInbetweenTimer) 
            { 
                currentDmgInbetweenTimer = 0;
                collision.gameObject.GetComponent<EnemyStatusManager>().Damaged(damage);

            }
        }
        //first time után
        else
        {
            collision.gameObject.GetComponent<EnemyStatusManager>().Damaged(damage);
            collision.gameObject.GetComponent<EnemyStatusManager>().GarlicHasFirstHit = true;
        }

            
    }
}

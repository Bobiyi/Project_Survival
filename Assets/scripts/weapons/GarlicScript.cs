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
    [SerializeField] private Animator animator;
    public float GetDamage { get => damage; set => damage = value; }
    public float DmgInbetweenTimer { get => dmgInbetweenTimer; set => dmgInbetweenTimer = value; }

    // Start is called before the first frame update
    void Start()
    {
        Enabled = true;
        Collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        AreaUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Enabled)
        {
            Collider.radius = 0;
            sprite.transform.localScale = new Vector2(0,0);
        }




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
                enemyScript.Damaged(damage);
                enemyScript.GarlicHasFirstHit = false;
                enemyScript.GarlicCurrentTime = 0;
            }
            if (enemyScript.GarlicCurrentTime >= enemyScript.GarlicTimer)
            {
                enemyScript.Damaged(damage);
                enemyScript.GarlicCurrentTime = 0;

            }
        }
       
    }

    
}

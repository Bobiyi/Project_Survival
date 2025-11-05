using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class whipScript : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float area;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float level;
    [SerializeField] private float projectileCount;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer sprite;

    private float currentAS;

    private void Start()
    {
        boxCollider.enabled = false;
        sprite.enabled = false;
        currentAS = attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        boxCollider.enabled = false;
        sprite.enabled = false;
        if (currentAS >= attackSpeed)
        {
            Attack();
            currentAS = 0f;
        }
        else
        {
            currentAS += Time.deltaTime;
        }



    }

    void Attack()
    {
        boxCollider.enabled = true;
        sprite.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }


}

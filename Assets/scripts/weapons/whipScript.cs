using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class whipScript : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float areaMultiplier;
    [SerializeField] private float onScreenTime;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float knockback;

    private float currentAS;
    private float currentOnScreen;

    private void Start()
    {
        currentOnScreen = 0;
        Vector2 whipSize = new Vector2(
            x: 4.5f * areaMultiplier, 
            y: 2f * areaMultiplier);
        transform.localScale = whipSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentOnScreen >= onScreenTime)
        {
            Destroy(gameObject);
        }
        else
        {
            currentOnScreen += Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStatusManager>().Damaged(damage, knockback);
        }
    }


}

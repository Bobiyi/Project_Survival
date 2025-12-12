using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class whipScript : MonoBehaviour
{
    private float damage;
    private float areaMultiplier;
    [SerializeField] private float onScreenTime;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer sprite;
    private float knockback;

    private float currentAS;
    private float currentOnScreen;

    private void Start()
    {
        WhipManager manager = GameObject.Find("Whip").GetComponent<WhipManager>();
        damage = manager.CurrDmg;
        areaMultiplier = manager.BaseSizeMult;

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

    public void setKnockback(float knockback)
    {
        this.knockback = knockback;
    }


}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class whipScript : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float area;
    [SerializeField] private float level;
    [SerializeField] private float onScreenTime;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer sprite;

    private float currentAS;
    private float currentOnScreen;

    private void Start()
    {
        currentOnScreen = 0;
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
            Destroy(collision.gameObject);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NtroShotScript : MonoBehaviour
{
    [SerializeField] float maxOnScreenTime;
    [SerializeField] GameObject player;
    [SerializeField] GameObject parent;
    float damage;
    float onScreenTimer;

    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
        player = GameObject.Find("Player");
        onScreenTimer = 0;
        damage = player.GetComponentInChildren<NitroManagerScript>().Damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (onScreenTimer >= maxOnScreenTime)
        {
            Destroy(parent);
        }
        else
        {
            onScreenTimer += Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStatusManager>().Damaged(damage, 0f);
        }
    }
}

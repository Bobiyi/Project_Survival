using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

     public int health = 100;
     public int damage = 10;
     public int armor = 1;

    [SerializeField] private ParticleSystem particles;

    [SerializeField] private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Take Damage")]
    public void TakeDamage(int damageTaken)
    {
        sprite.color = Color.red;

        health = health - (damageTaken - armor);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 10;
    [SerializeField] private int armor = 1;
    [SerializeField] private int xp = 0;

    [SerializeField] private ParticleSystem particles;

    [SerializeField] private SpriteRenderer sprite;

    public int Health { get => health; }
    public int Damage { get => damage; set => damage = value; }
    public int Armor { get => armor; set => armor = value; }
    public int XP { get => xp; set => xp = value; }


    [ContextMenu("Take Damage")]
    public void TakeDamage(int damageTaken)
    {
        sprite.color = Color.red;

        health = health - (damageTaken - armor);
    }

}

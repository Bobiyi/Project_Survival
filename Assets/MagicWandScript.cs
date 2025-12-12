using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWandScript : MonoBehaviour, weapon
{
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private float damage;
    [SerializeField] private float knockback;
    [SerializeField] private float attackSpeed;
    private float currentCD;
    private Vector2 nearestEnemy;

    public float Damage { get => damage; set => damage = value; }
    public float Knockback { get => knockback; set => knockback = value; }
    void Start()
    {
        currentCD = attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCD>=attackSpeed)
        {
            shoot();
            currentCD = 0;
        } 
        else
        {
            currentCD += Time.deltaTime;
        }
    }

    private void shoot()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        

    }

    public void lvlup(int lvls)
    {
        throw new NotImplementedException();
    }
}

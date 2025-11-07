using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusManager : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float speed;
    [SerializeField] private GameObject XPpref;
    //[SerializeField] private float hp;

    private bool garlicHasFirstHit;

    public bool GarlicHasFirstHit { get => garlicHasFirstHit; set => garlicHasFirstHit = value; }
    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        GarlicHasFirstHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damaged(float damage)
    {
        hp -= damage; 
        if(hp <= 0)
        {
            Instantiate(XPpref,
                position: new Vector2(transform.position.x, transform.position.y - 0.75f),
                rotation: Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

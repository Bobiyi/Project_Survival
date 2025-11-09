using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusManager : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float speed;
    [SerializeField] private GameObject XPpref;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private GameObject player;


    private GarlicScript garlic;
    private Color originalColor;
    private bool garlicHasFirstHit;
    private float garlicTimer;
    private float garlicCurrentTime = 0;

    public bool GarlicHasFirstHit { get => garlicHasFirstHit; set => garlicHasFirstHit = value; }
    public float Speed { get => speed; set => speed = value; }
    public float GarlicTimer { get => garlicTimer; set => garlicTimer = value; }
    public float GarlicCurrentTime { get => garlicCurrentTime; set => garlicCurrentTime = value; }

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");
        garlic = player.GetComponentInChildren<GarlicScript>();
        GarlicTimer = garlic.DmgInbetweenTimer;
        GarlicHasFirstHit = false;
        originalColor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(!(GarlicCurrentTime >= GarlicTimer))
        {
            GarlicCurrentTime += Time.deltaTime;
        }
  

    }
  
    public void Damaged(float damage, float knockbackStrenght)
    {
        hp -= damage; 
        if(hp <= 0)
        {
            
            Instantiate(XPpref,
                position: new Vector2(transform.position.x, transform.position.y - 0.75f),
                rotation: Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(ColorChange());
            //Knockback(knockbackStrenght);
        }
    }
    /*public void Knockback(float strenght)
    {
        if(strenght != 0)
        {
            Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
            body.transform.position = Vector2.Lerp(transform.position, new Vector2(10, 10), 10f * Time.deltaTime);
        }
    }*/

    IEnumerator ColorChange()
    {
        sprite.color = new Color(
            r: 255,
            g: 0,
            b: 0);

        yield return new WaitForSeconds(0.5f);

        new WaitForSeconds(0.5f);
        sprite.color = new Color(
            r: originalColor.r,
            g: originalColor.g,
            b: originalColor.b);
    }

}

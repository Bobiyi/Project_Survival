using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

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


    public bool IsKnockedBack { get; private set; }
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
        gameObject.transform.rotation = Quaternion.Euler(0f,0f,0f);
            

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
            Knockback(knockbackStrenght);
        }
    }
    public void Knockback(float strength)
    {
        if (strength == 0 || player == null) return;
        
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();

        Vector2 direction = (transform.position - player.transform.position).normalized;

        if (body == null)
        {
            Debug.LogWarning("[EnemyStatusManager] No Rigidbody2D on " + name, this);

            Vector2.MoveTowards(transform.position,direction,strength);
            StartCoroutine(KnockbackTimer(0.7f, body));

        }

        
        if (!IsKnockedBack)
        {

            body.velocity = direction * strength;
            StartCoroutine(KnockbackTimer(0.7f, body));
        }

            var ai = GetComponent<EnemyMovementScript>();
            if (ai != null) ai.DisableMovement(0.7f);
        
    }

    private IEnumerator KnockbackTimer(float duration, Rigidbody2D body)
    {
        IsKnockedBack = true;
        yield return new WaitForSeconds(duration);
        // stop residual sliding
        if (body != null)
        {
            body.velocity = Vector2.zero;
        }
        IsKnockedBack = false;
    }

    IEnumerator ColorChange()
    {
        sprite.color = Color.red;

        yield return new WaitForSeconds(0.5f);

        new WaitForSeconds(0.5f);
        sprite.color = new Color(
            r: originalColor.r,
            g: originalColor.g,
            b: originalColor.b);
    }

}

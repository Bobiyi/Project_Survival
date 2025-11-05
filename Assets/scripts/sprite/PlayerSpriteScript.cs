using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerSpriteScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    public bool isFlipped;

    // Start is called before the first frame update
    void Start()
    {
        isFlipped = false;
        if (sprite == null)
        {
            sprite = GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            sprite.flipX = true;
            isFlipped = true;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            sprite.flipX = false;
            isFlipped = false;
        }
    }
    public bool getIsFlipped() { return isFlipped; }
}

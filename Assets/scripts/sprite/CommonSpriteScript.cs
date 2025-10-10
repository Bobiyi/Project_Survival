using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSpriteScript : MonoBehaviour
{
    [SerializeField] private GameObject playerPosition;
    [SerializeField] private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        if (playerPosition == null)
        {
            playerPosition = GameObject.FindWithTag("Player");
        }
        if (sprite == null)
        {
            sprite = GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > playerPosition.transform.position.x)
        {
            sprite.flipX = false;

        } else
        {
            sprite.flipX = true;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class XpScript : MonoBehaviour
{

    [SerializeField] private PlayerManager playerScript;

    private void Start()
    {
        if(playerScript==null)
        {
            GameObject playerObj = GameObject.Find("Player");
            if(playerObj != null)
            {
                playerScript = playerObj.GetComponent<PlayerManager>();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            Destroy(gameObject);

            playerScript.XP += 10;

            Debug.Log("XP gained");
        }

    }
}

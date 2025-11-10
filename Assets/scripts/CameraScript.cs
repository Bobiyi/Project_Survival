using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float followSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
        if(player == null)
        {
            GameObject pgo = GameObject.FindWithTag("Player");
            if (pgo != null) player = pgo.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Vector3 targetPos = player.position;
        targetPos.z = transform.position.z;

        transform.position = Vector3.Lerp(
            a: transform.position,
            b: targetPos,
            t: followSpeed * Time.deltaTime);
    }
}

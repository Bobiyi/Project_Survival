using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject commonEnemy;

    [SerializeField] private int spawnTime = 3;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(methodName:"spawn", time:0f, repeatRate:spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void spawn()
    {
        Instantiate(commonEnemy, transform.position, Quaternion.identity);
    }

}

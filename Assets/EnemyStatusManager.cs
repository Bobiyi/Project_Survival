using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusManager : MonoBehaviour
{
    private bool garlicHasFirstHit;

    public bool GarlicHasFirstHit { get => garlicHasFirstHit; set => garlicHasFirstHit = value; }

    // Start is called before the first frame update
    void Start()
    {
        GarlicHasFirstHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

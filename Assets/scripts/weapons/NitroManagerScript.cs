using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NitroManagerScript : MonoBehaviour
{
    [SerializeField] GameObject nitroShotPrefab;
    [SerializeField] float damage;
    [SerializeField] float cooldown;
    float cooldownCurrent;

    public float Damage { get => damage; set => damage = value; }



    // Start is called before the first frame update
    void Start()
    {
        cooldownCurrent = 0f;

    }


    // Update is called once per frame
    void Update()
    {

        if (cooldownCurrent >= cooldown)
        {
            shoot();
            cooldownCurrent = 0f;
        }
        else
        {
            cooldownCurrent += Time.deltaTime;
        }
    }

    private Transform GetClosestEnemy(GameObject[] enemies)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget.transform;
    }

        void shoot()
    {
        Transform target = GetClosestEnemy(GameObject.FindGameObjectsWithTag("Enemy");





        var shot = Instantiate(
        original: nitroShotPrefab,
        position: new Vector3(transform.position.x, transform.position.y),
        rotation: Quaternion.Euler(0, 0, Random.Range(0, 360))
        );
    }
}

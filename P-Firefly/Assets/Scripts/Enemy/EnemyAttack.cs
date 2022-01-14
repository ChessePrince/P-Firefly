using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float startTimeBtwShots;
    private float timeBtwShots;

    public GameObject prefabGlow;
    public Transform goFirePoint;

    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }
    private void Update()
    {
        RangedAttack();
    }
    void RangedAttack()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(prefabGlow, goFirePoint.position, goFirePoint.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}

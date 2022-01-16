using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float startTimeBtwShots = 0.5f;
    private float timeBtwShots;

    public GameObject prefabGlow;
    public Transform goFirePoint;

    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        RandomizeValues();
    }
    private void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            RangedAttack();
        }
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
    void RandomizeValues()
    {
        startTimeBtwShots = Random.Range(0.5f, 2f);
    }
}

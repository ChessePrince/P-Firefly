using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float startTimeBtwShots = 0.5f;
    private float timeBtwShots;

    public GameObject prefabGlow;
    public Transform goFirePoint;

    EnemyAnimations anim;

    private bool playerIsNear;
    void Start()
    {
        RandomizeValues();
        anim = GetComponent<EnemyAnimations>();
        playerIsNear = true; //change later
    }
    private void Update()
    {
        if (!PauseControl.gameIsPaused && playerIsNear)
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
            anim.Squash();
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    void RandomizeValues()
    {
        startTimeBtwShots = Random.Range(0.5f, 2f);
        timeBtwShots = startTimeBtwShots;
    }
}

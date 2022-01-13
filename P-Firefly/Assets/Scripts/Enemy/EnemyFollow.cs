using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform playerPos;
    private Transform compTransform;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public float startTimeBtwShots;
    private float timeBtwShots;

    public GameObject goProjectile;
    public Transform GOMuzzle;

    public float offset;

   
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, playerPos.position) < stoppingDistance && Vector2.Distance(transform.position, playerPos.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, playerPos.position) > retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, -speed * Time.deltaTime);
        }
        //RangedAttack();
        LookAtPlayer();
    }
    void RangedAttack()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(goProjectile, GOMuzzle.position, GOMuzzle.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    void LookAtPlayer()
    {
        Vector3 difference = playerPos.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
}

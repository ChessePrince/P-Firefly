using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    bool hasEntered;
    public GameObject Enemy1, Enemy2, Enemy3, Enemy4;

    private void Awake()
    {
        hasEntered = false;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!hasEntered)
            {
                hasEntered = true;
                Enemy1.SetActive(true);
                Enemy2.SetActive(true);
            }
            else
            {
                
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject goParticleFx;
    public bool toSpawn;

    private void Awake()
    {
        if(toSpawn)
            gameObject.SetActive(false);
        else 
            gameObject.SetActive(true);
    }
    public void Spawn()
    {
        gameObject.SetActive(true);
        Instantiate(goParticleFx, transform.position, Quaternion.identity);
    }
}

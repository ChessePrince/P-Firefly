using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtSpawn : MonoBehaviour
{
    [SerializeField] GameObject goParticleFx;
    CharacterSfx sfx;
    private void Awake()
    {
        sfx = GetComponentInChildren<CharacterSfx>();
    }
    private void OnEnable()
    {
        Instantiate(goParticleFx, transform.position, Quaternion.identity);
        //sfx.PlaySpawn();
        Debug.Log("azf");
    }
}

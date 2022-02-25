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
    void Start()
    {
        Instantiate(goParticleFx, transform.position, Quaternion.identity);
        sfx.PlaySpawn();
    }
}

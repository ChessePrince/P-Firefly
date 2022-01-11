using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private enum State
    {
        Idle,
        Active,
        BattleOver
    }
    
    [SerializeField] private EnemySpawn[] enemySpawnArray;
    int numOfEnemies;
    [SerializeField] private ColliderTrigger colliderTrigger;
    bool hasSpawned;

    private State state;

    public DoorManager[] compDoorManager;

    private void Start()
    {
        //colliderTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
        hasSpawned = false;
        state = State.Idle;
        numOfEnemies = enemySpawnArray.Length;
        
    }
    private void Update()
    {
        TestBattleOver();
        Debug.Log(state);
    }/*
    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if (state == State.Idle)
        {
            StartBattle();
        }
    }*/
    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if (state == State.Idle)
        {
            StartBattle();
        }
    }
    private void StartBattle()
    {
        Debug.Log("start battle");
        state = State.Active;

        foreach (EnemySpawn enemySpawn in enemySpawnArray)
        {
            FindObjectOfType<HitStop>().Stop(0.1f);
            enemySpawn.Spawn();
            hasSpawned = true;
            compDoorManager[0].CloseDoor();
            compDoorManager[1].CloseDoor();
        }
    }
    public bool IsWaveOver()
    {
        if (hasSpawned && numOfEnemies==0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void TestBattleOver()
    {
        if (IsWaveOver())
        {
            //battle over
            state = State.BattleOver;
            Debug.Log("you done did it");
            FindObjectOfType<HitStop>().Stop(0.5f, 0.8f);
            compDoorManager[0].OpenDoor();
            compDoorManager[1].OpenDoor();
            StartCoroutine(Wait());

        }
    }

    public void EnemyDefeated()
    {
        numOfEnemies--;
    }
    void DestroyAllProyectiles()
    {
        if (state == State.BattleOver)
        {/*
            GameObject[] pProjectiles = GameObject.FindGameObjectsWithTag("PProjectile");
            foreach (GameObject pProjectile in pProjectiles)
                GameObject.Destroy(pProjectile);

            GameObject[] eGlows = GameObject.FindGameObjectsWithTag("EProjectile");
            foreach (GameObject eGlow in eGlows)
                GameObject.Destroy(eGlow);*/
        }
    }
    IEnumerator Wait()
    {
        DestroyAllProyectiles();
        yield return new WaitForSeconds(1f);
        state = State.Idle;
    }
}

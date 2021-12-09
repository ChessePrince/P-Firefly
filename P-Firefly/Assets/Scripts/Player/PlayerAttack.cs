using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject GOBullet;
    [SerializeField] Transform GOMuzzle;

    void Start()
    {
        
    }
    void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            Attack(GOMuzzle);
        }
    }
    public void Attack(Transform muzzle)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(GOBullet, muzzle.position, muzzle.rotation);
        }
    }
}

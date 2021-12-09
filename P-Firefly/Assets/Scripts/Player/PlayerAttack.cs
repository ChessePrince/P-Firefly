using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject prefabGlow;
    [SerializeField] Transform goFirePoint;

    void Start()
    {
        
    }
    void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            Attack(goFirePoint);
        }
    }
    public void Attack(Transform muzzle)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefabGlow, muzzle.position, muzzle.rotation);
        }
    }
}

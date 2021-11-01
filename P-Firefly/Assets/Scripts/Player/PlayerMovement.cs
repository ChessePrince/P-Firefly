using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float MOVE_SPEED = 15f;
    private Rigidbody2D compRB;
    private Vector3 moveDir;

    [SerializeField] PlayerAnim compPlayerAnim;
    ParticleTrail compParticleTrail;

    private void Awake()
    {
        compRB = GetComponent<Rigidbody2D>();
        //compPlayerAnim = GetComponent<PlayerAnim>();
        compParticleTrail = GetComponent<ParticleTrail>();
    }

    void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            Movement();
        }
        //Debug.Log(stateDir);
    }
    void Movement()
    {
        float moveX = 0f;
        float moveY = 0f;
        
        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
            //moveX = 0f;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
            //moveX = 0f;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            //moveY = 0f;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
            //moveY = 0f;
            
        }
        moveDir = new Vector3(moveX, moveY).normalized;
        compPlayerAnim.PlayerAnimations(moveDir);
        ParticleTrail();
    }
    private void FixedUpdate()
    {
        compRB.velocity = moveDir * MOVE_SPEED;
    }
    void ParticleTrail()
    {
        if(moveDir != new Vector3(0, 0))
        {
            compParticleTrail.StartTheTrail();

        }
    }
}

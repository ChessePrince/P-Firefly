using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    SpriteRenderer compSR;
    Rigidbody2D compRB;
    Animator compAnim;
    Transform compTransform;
    PlayerMovement compPlayerMovement;

    void Awake()
    {
        compSR = GetComponent<SpriteRenderer>();
        compRB = GetComponent<Rigidbody2D>();
        compAnim = GetComponent<Animator>();
        compTransform = GetComponent<Transform>();
        compPlayerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {

    }
    public void PlayerAnimations(Vector3 dir)
    {
        if(dir.y > 0)
        {
            PlayerUp();
        }
        if (dir.y < 0)
        {
            PlayerDown();
        }
        if (dir.x < 0)
        {
            PlayerRight();
        }
        if (dir.x > 0)
        {
            PlayerLeft();
        }


        if ( (dir.x > 0)&&(dir.y > 0) )
        {
            PlayerNorthEast();
        }
        if ((dir.x < 0) && (dir.y > 0))
        {
            PlayerNorthWest();
        }
        if ((dir.x < 0) && (dir.y < 0))
        {
            PlayerSouthWest();
        }
        if ((dir.x > 0) && (dir.y < 0))
        {
            PlayerSouthEast();
        }
    }
    public void PlayerUp()
    {
        compTransform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    public void PlayerDown()
    {
        compTransform.localRotation = Quaternion.Euler(0, 0, 180);
    }
    public void PlayerRight()
    {
        compTransform.localRotation = Quaternion.Euler(0, 0, 90);
    }
    public void PlayerLeft()
    {
        compTransform.localRotation = Quaternion.Euler(0, 0, 270);
    }


    public void PlayerNorthEast()
    {
        compTransform.localRotation = Quaternion.Euler(0, 0, -45);
    }
    public void PlayerNorthWest()
    {
        compTransform.localRotation = Quaternion.Euler(0, 0, 45);
    }
    public void PlayerSouthWest()
    {
        compTransform.localRotation = Quaternion.Euler(0, 0, 135);
    }
    public void PlayerSouthEast()
    {
        compTransform.localRotation = Quaternion.Euler(0, 0, 225);
    }
}

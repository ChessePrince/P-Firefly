using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    void Start()
    {

    }
    public void Squash()
    {
        anim.Play("PlayerSquash");
    }
    public void Idle()
    {
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerIdle"))
        {
            anim.Play("PlayerIdle");
        }   
    }
}

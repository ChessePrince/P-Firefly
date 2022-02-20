using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Squash()
    {
        anim.Play("MothSquash");
    }
    public void Idle()
    {
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("MothIdle"))
        {
            anim.Play("MothIdle");
        }
    }
}

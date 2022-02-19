using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    Animator compAnimator;
    private string currentState;
    private void Start()
    {
        compAnimator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        ChangeAnimationState("door open");
    }
    public void CloseDoor()
    {
        ChangeAnimationState("door close");
    }
    void ChangeAnimationState(string newState)
    {
        //stop the anim from interrupting itself
        if (currentState == newState) return;

        //play the anim
        compAnimator.Play(newState);

        //reassign the current state
        currentState = newState;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    //public event EventHandler OnPlayerEnterTrigger;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("WE IN");
            //OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }

    }
}

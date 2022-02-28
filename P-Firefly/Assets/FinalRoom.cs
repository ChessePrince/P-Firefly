using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalRoom : MonoBehaviour
{
    bool hasEntered;
    [SerializeField] GameObject[] enemy1;

    public GameObject Entrance;
    public GameObject Congrats;

    public GameObject Number;
    RoomNumber roomNumber;
    private void Awake()
    {
        hasEntered = false;
        roomNumber = Number.GetComponent<RoomNumber>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!hasEntered)
            {
                hasEntered = true;
                for (int i = 0; i < enemy1.Length; i++)
                {
                    enemy1[i].SetActive(true);
                }
                Entrance.SetActive(true);
                RoomNumber.roomNum = 8;
                roomNumber.NextRoom();
            }
            else
            {
                return;
            }
            
        }
    }
    private void Update()
    {
        if ((EnemyManager.numberOfEnemies == 0) && (hasEntered))
        {
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        print("waiting");
        yield return new WaitForSeconds(0.25f);
        Congrats.SetActive(true);
        Destroy(gameObject);
    }
}

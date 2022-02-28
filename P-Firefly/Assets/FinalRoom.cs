using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalRoom : MonoBehaviour
{
    bool hasEntered;
    [SerializeField] GameObject[] enemy1;
    [SerializeField] GameObject[] enemy2;
    bool finished;
    public GameObject Entrance;
    public GameObject Congrats;
    int wave;
    public GameObject waveText;
    TextMeshProUGUI text;
    public GameObject Number;
    RoomNumber roomNumber;
    private void Awake()
    {
        hasEntered = false;
        finished = false;
        text = waveText.GetComponent<TextMeshProUGUI>();
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
                wave = 1;
                waveText.SetActive(true);
                text.text = "1/2";
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
        if (EnemyManager.numberOfEnemies == 0 && hasEntered && !finished) //the end 
        {
            StartCoroutine("WaitSeconds");
        }
        if (EnemyManager.numberOfEnemies == 0 && finished)
        {
            StartCoroutine("Wait");
        }
    }
    void Wave2()
    {
        if (wave == 1)
        {
            for (int i = 0; i < enemy2.Length; i++)
            {
                enemy2[i].SetActive(true);
            }
            finished = true;
        }
    }
    IEnumerator WaitSeconds()
    {
        text.text = "2/2";
        yield return new WaitForSeconds(1.5f);
        Wave2();
    }
    IEnumerator Wait()
    {
        print("waiting");
        yield return new WaitForSeconds(0.25f);
        Congrats.SetActive(true);
        //Destroy(gameObject);
    }
}

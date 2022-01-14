using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PManagmentHealth : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;
    public Text testText;

    private void Awake()
    {
        //testText = GetComponent<Text>();
    }
    public void UpdateHealthUI(int playerHealth, int numOfHearts)
    {
        if (playerHealth > numOfHearts)
        {
            playerHealth = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void UpdateHealthUI(int playerHealth)
    {
        testText.text = ("HP = " + playerHealth.ToString());
    }
}
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

    public Image HealthBar;


    private void Awake()
    {
       
    }
    public void UpdateHealthUI(float playerHealth, float maxPlayerHealth)
    {
        //testText.text = ("P HP = " + playerHealth.ToString());
        HealthBar.fillAmount = playerHealth / maxPlayerHealth;
        Debug.Log(playerHealth);
    }
}

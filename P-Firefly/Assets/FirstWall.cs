using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWall : MonoBehaviour
{
    int health;
    public GameObject ExpDeath;
    public Material matWhite;
    Material matDefault;
    SpriteRenderer compRnd;
    private void Start()
    {
        compRnd = GetComponent<SpriteRenderer>();
        health = 3;
        matDefault = compRnd.material;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PinkGlow")
        {
            health--;
            compRnd.material = matWhite;
            StartCoroutine(BackToDefaultMaterial());
        }
    }
    void WallDestroyed()
    {
        Instantiate(ExpDeath, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (health <= 0)
            WallDestroyed();
    }
    IEnumerator BackToDefaultMaterial()
    {
        while (Time.timeScale != 1.0f)
            yield return null;//wait for hit stop to end
        compRnd.material = matDefault;
    }
}

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
        health = 2;
        matDefault = compRnd.material;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PinkGlow")
        {
            health--;
            compRnd.material = matWhite;
            FindObjectOfType<HitStop>().Stop(0.025f);
            StartCoroutine(BackToDefaultMaterial());
        }
    }
    void WallDestroyed()
    {
        Instantiate(ExpDeath, transform.position, Quaternion.identity);
        Destroy(gameObject);
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

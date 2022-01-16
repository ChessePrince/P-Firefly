using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    int health = 5;

    SpriteRenderer compRnd;
    public Material matWhite;
    Material matDefault;
    
    void Awake()
    {
        compRnd = GetComponent<SpriteRenderer>();
        //hitShader = Shader.Find("GUI/Text Shader");
        matDefault = compRnd.material;
    }
    void TakeDamage(int amount)
    {
        //Instantiate(hurtSound, transform.position, Quaternion.identity);
        health -= amount;
        Debug.Log(health+" enemy hp");

        //StartCoroutine(ExecutePlayerFlash());

        //UpdateHealthUI(health);
        //hurtAnim.SetTrigger("hurt");
        
        if (health <= 0)
        {
            //FindObjectOfType<BattleSystem>().EnemyDefeated();
            Destroy(this.gameObject);
            //sceneTransitions.LoadScene("Lose");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PinkGlow")
        {
            //other.GetComponent<Enemy>().TakeDamage(damage);
            //DestroyProjectile();
            TakeDamage(1);
            HitFeedback();
        }
    }
    IEnumerator BackToDefaultMaterial()
    {
        while (Time.timeScale != 1.0f)
            yield return null;//wait for hit stop to end
        compRnd.material = matDefault;
        //compRnd.material.color = Color.white;
        //Instantiate(breakPrefab, transform.position, Quaternion.identity);
        //Destroy(gameObject);
    }
    void HitFeedback()
    {
        compRnd.material = matWhite;
        //compRnd.material.color = Color.white;

        FindObjectOfType<HitStop>().Stop(0.05f);
        StartCoroutine(BackToDefaultMaterial());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float health;
    //public GameObject GOplayer;
    SpriteRenderer compRnd;
    public Material matWhite;
    Material matDefault;
    //public GameObject GOfireflyLight;
    public PManagmentHealth HealthManager;
    PlayerAnimation anim;

    void Awake()
    {
        compRnd = GetComponent<SpriteRenderer>();
        matDefault = compRnd.material;
        anim = GetComponent<PlayerAnimation>();
        health = maxHealth;
    }
    private void Start()
    {
        UpdateHealth();
    }
    void TakeDamage(int amount)
    {
        //Instantiate(hurtSound, transform.position, Quaternion.identity);
        health -= amount;
        UpdateHealth();
        //StartCoroutine(ExecutePlayerFlash());
        compRnd.material = matWhite;
        anim.Squash();
        //FindObjectOfType<HitStop>().Stop(0.06f);
        FindObjectOfType<HitStop>().Stop(0.1f);
        StartCoroutine(WaitForIFrames());

        //UpdateHealthUI(health);
        //hurtAnim.SetTrigger("hurt");
        if (health <= 0)
        {
            //Destroy(GOplayer);
            //sceneTransitions.LoadScene("Lose");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GreenGlow")
        {
            //other.GetComponent<Enemy>().TakeDamage(damage);
            //DestroyProjectile();
            TakeDamage(1);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            //other.GetComponent<Enemy>().TakeDamage(damage);
            //DestroyProjectile();
            TakeDamage(1);
        }
    }
    IEnumerator WaitForIFrames()
    {
        while (Time.timeScale != 1.0f)
            yield return null;//wait for hit stop to end
        compRnd.material = matDefault;
        StartCoroutine(InvFrame());      
        //Instantiate(breakPrefab, transform.position, Quaternion.identity);
    }
    private IEnumerator InvFrame()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        compRnd.color = new Color(1f, 1f, 1f, 0.75f);
        //GOfireflyLight.SetActive(false);

        yield return new WaitForSeconds(0.75f);

        Physics2D.IgnoreLayerCollision(8, 9, false);
        compRnd.color = new Color(1f, 1f, 1f, 1f);
        //GOfireflyLight.SetActive(true);
    }
    private void Update()
    {

    }
    void UpdateHealth()
    {
        HealthManager.UpdateHealthUI(health, maxHealth);
    }
}

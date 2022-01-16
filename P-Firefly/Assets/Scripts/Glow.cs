using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    private Rigidbody2D compRB;
    public float vel;
    //ParticleTrail compParticleTrail;
    public GameObject prefabExplosionG;

    private void Awake()
    {
        compRB = GetComponent<Rigidbody2D>();
        //compParticleTrail = GetComponent<ParticleTrail>();
    }
    void Start()
    {
        Move(1);
    }
    private void Update()
    {
        //compParticleTrail.StartTheTrail();
    }
    void Move(int dir)
    {    
        compRB.velocity = dir*transform.up*Time.deltaTime *vel; 
    }
    public void DestroyAllProyectiles()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        DestroyGlow();
        /*
        if (collision.gameObject.tag == targetTag)
        {
            //other.GetComponent<Enemy>().TakeDamage(damage);
        }*/

    }
    void DestroyGlow()
    {
        GameObject effect = Instantiate(prefabExplosionG, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}

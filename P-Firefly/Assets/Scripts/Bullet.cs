using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D compRB;
    public float vel;
    //ParticleTrail compParticleTrail;
    public GameObject GOparticleExp;
    public GameObject GOparticleMini;
    public string targetTag;


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
    }/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(GOparticleMini, transform.position, Quaternion.identity);
        Destroy(effect, 2f);

        if (collision.gameObject.tag == targetTag)
        {
            GameObject effect2 = Instantiate(GOparticleExp, transform.position, Quaternion.identity);
            Destroy(effect2, 2f);
            Destroy(gameObject);
            //other.GetComponent<Enemy>().TakeDamage(damage);
            //DestroyProjectile();
        }
    }*/
}

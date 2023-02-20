using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] AudioClip hit_SFX,kill_SFX;

    [SerializeField] int Score_value;
    [SerializeField] int Enemy_health;

    GameObject storage;
    Score sc;

    void Start()
    {
        storage = GameObject.FindGameObjectWithTag("Tag_Storage");
        sc = FindObjectOfType<Score>();
        addRigidbody();

    }






    void OnParticleCollision(GameObject h)
    {
        Score();

        if (Enemy_health < 1)
        {
            Enemy_kill();
        }

    }







    void addRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    





    void Score()
    {
        Enemy_health--;
        
        
        GameObject vfx_enemy = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx_enemy.transform.parent = storage.transform;
    }


    void Enemy_kill()
    {
        sc.Score_increase(Score_value);

        GameObject vfx_enemy = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx_enemy.transform.parent = storage.transform;
        Destroy(gameObject);
    }

    
}

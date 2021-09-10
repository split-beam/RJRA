using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scoreIncerase = 15;
    [SerializeField] int hitPoints = 2;

    bool exploding = false;

    ScoreBoad scoreBoad;
    GameObject parentGameObject;
    

    void Start()
    {
        scoreBoad = FindObjectOfType<ScoreBoad>();
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRunTime");
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        if (exploding) { return; }
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints--;
        scoreBoad.IncreaseScore(scoreIncerase);
    }
    void KillEnemy()
    {
        exploding = true;
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        scoreBoad.IncreaseScore(scoreIncerase*2);
        Destroy(gameObject);
    }

   
}

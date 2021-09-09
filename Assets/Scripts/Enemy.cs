using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scoreIncerase = 15;

    ScoreBoad scoreBoad;

    void Start()
    {
        scoreBoad = FindObjectOfType<ScoreBoad>();
    }

    bool exploding = false;
    void OnParticleCollision(GameObject other)
    {
        if (exploding) { return; }
        ProcessHit();
        KillEnemy();
    }

    void ProcessHit()
    {
        scoreBoad.IncreaseScore(scoreIncerase);
    }
    void KillEnemy()
    {
        exploding = true;
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

   
}

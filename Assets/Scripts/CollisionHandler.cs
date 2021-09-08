using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem PartExplosion;

    bool isTransitioning = false;

    void OnTriggerEnter(Collider other)
    {
        if (isTransitioning) { return; }
        Debug.Log($"{this.name} **Collided With** {other.gameObject.name}");
        CrashRestart();
        //Debug.Log(this.name + "--Collided With--" + collision.gameObject.name);
    }

    void CrashRestart()
    {
        isTransitioning = true;
        PartExplosion.Play();
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }
    void ReloadLevel()
    {
        //Use int for levels, strings for menus  SceneManager.LoadScene("Sandbox") ||  SceneManager.LoadScene("0"). Current example restarts current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

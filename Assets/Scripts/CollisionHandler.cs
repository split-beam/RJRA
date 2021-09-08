using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{this.name} **Collided With** {collision.gameObject.name}");
        //Debug.Log(this.name + "--Collided With--" + collision.gameObject.name);
    }


}

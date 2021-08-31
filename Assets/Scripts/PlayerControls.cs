using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        float xthrow = Input.GetAxis("Horizontal");
        float ythrow = Input.GetAxis("Vertical");

        float xOffset = xthrow * Time.deltaTime * controlSpeed;
        float newXPos = transform.localPosition.x + xOffset;

        float yOffset = ythrow * Time.deltaTime * controlSpeed;
        float newYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
        //Debug.Log(xthrow);
        //Debug.Log(ythrow);
    }
}

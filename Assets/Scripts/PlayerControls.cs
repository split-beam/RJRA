using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2.5f;
    [SerializeField] float controlRollFactor = -2f;

    [SerializeField] private float rotationFactor;


    float xthrow, ythrow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        xthrow = Input.GetAxis("Horizontal");
        ythrow = Input.GetAxis("Vertical");


        float xOffset = xthrow * Time.deltaTime * controlSpeed;
        float RawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(RawXPos, -xRange, xRange);

        float yOffset = ythrow * Time.deltaTime * controlSpeed;
        float RawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(RawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = ythrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xthrow * controlRollFactor;

        //transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        // On next line, we get the target rotation but we don't assign it to transform.localRotation
        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);
        // here, we use Quaternion.RotateTowards from the current rotation
        // to the target rotation. NOTE that the rotationFactor has to be small, such as 1, otherwise the rotation will be too fast and will be janky.
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationFactor);
    }

    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            Debug.Log("Fire");
        }
        else
        {
            return;
        }
    }
}

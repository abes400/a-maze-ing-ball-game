using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    
    [SerializeField]
    float rotationAngle = 30.0f;

    [SerializeField]
    float rotationTime = 00.2f;

    float currentVelocity = 00.0f;
    float targetAngle     = 00.0f;
                     

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            targetAngle += rotationAngle;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            targetAngle -= rotationAngle;

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref currentVelocity, rotationTime);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
    }
}

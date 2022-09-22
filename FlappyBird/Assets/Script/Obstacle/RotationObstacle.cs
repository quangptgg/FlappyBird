using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObstacle : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20.0f;
    private float minAngle = -30.0f;
    private float maxAngle = 30.0f;
    private Vector3 rotationAxis = new Vector3(0.0f, 0.0f, -1.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationAxis, angle);

        if (transform.rotation.z * Mathf.Rad2Deg <= minAngle)
        {
            rotationAxis = new Vector3(0.0f, 0.0f, 1.0f);
        }
        
        if (transform.rotation.z * Mathf.Rad2Deg >= maxAngle)
        {
            rotationAxis = new Vector3(0.0f, 0.0f, -1.0f);
        }
    }
}

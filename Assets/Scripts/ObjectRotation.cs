using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float rotationSpeed=1.0f;
    public Vector3 rotateAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateAxis * rotationSpeed * Time.deltaTime, Space.Self);
    }
}

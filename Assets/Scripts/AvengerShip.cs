using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvengerShip : MonoBehaviour
{
    bool forward = true;
    public float forwardSpeed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(forward)
        {
            transform.position += transform.forward * forwardSpeed * Time.deltaTime;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        forward = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipICamera : MonoBehaviour
{
    public float speed = 10f; 
    
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(560, 13, 350);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != new Vector3(560, 13, 17))
        {
            transform.position -= new Vector3(0, 0, 1) * Time.deltaTime * speed;
        }
    }
}
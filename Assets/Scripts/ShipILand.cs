using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipILand : MonoBehaviour
{
    RaycastHit hit;
    LayerMask land;
    // Start is called before the first frame update
    void Start()
    {
        land = ~land;
    }

    // Update is called once per frame
    void Update()
    {
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), out hit, 500f, land))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * hit.distance, Color.yellow);
        }
    }
}

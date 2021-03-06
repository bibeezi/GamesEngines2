using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanctuaryII : MonoBehaviour
{
    public Camera mainCamera;
    public Camera sideCamera;
    Arrive arrive;
    Boid boid;

    void Start()
    {
        arrive = GetComponent<Arrive>();
        boid = GetComponent<Boid>();

        arrive.targetPosition = mainCamera.gameObject.transform.position;
        boid.maxSpeed = 40f;
    }

    void Update() {
        if(transform.position.y < 370)
        {
            arrive.targetPosition = mainCamera.gameObject.transform.position + new Vector3(0, 300, 0);
        }
        if(Vector3.Distance(transform.position, arrive.targetPosition) < 20f)
        {
            mainCamera.enabled = false;
            sideCamera.enabled = true;
            boid.maxSpeed = 10f;
        }
        if(Vector3.Distance(transform.position, arrive.targetPosition) < 5f)
        {
            boid.enabled = false;
        }
    
    }
}
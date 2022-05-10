using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCamera : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Camera>().fieldOfView = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform.position);
        gameObject.GetComponent<Camera>().fieldOfView += 5f * Time.deltaTime;
    }
}

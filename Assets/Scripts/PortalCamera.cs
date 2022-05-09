using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Camera Shipcamera;
    public float speed = 7f; 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;

        if(transform.position.z > 120)
        {
            SceneManager.LoadScene(sceneName: "10FightScene");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Camera Shipcamera;
    public float speed = 7f; 
    public GameObject[] portals;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;
        
        portals = GameObject.FindGameObjectsWithTag("portal");

        if(portals.Length == 0)
        {
            SceneManager.LoadScene(sceneName: "10FightScene");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipICamera : MonoBehaviour
{
    public float speed = 7f; 
    
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(560, 13, 350);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, new Vector3(560, 13, 75)) > 20f)
        {
            transform.position -= new Vector3(0, 0, 1) * Time.deltaTime * speed;
        }
        else
        {
            SceneManager.LoadScene(sceneName: "7SanctuaryIILeviathans");
        }
    }
}
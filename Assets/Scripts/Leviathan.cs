using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Leviathan : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, gameObject.GetComponent<Seek>().target) < 200f)
        {
            SceneManager.LoadScene(sceneName: "9AvengersAssemble");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outrider : MonoBehaviour
{
    public int outriderSpeed;
    UnityEngine.AI.NavMeshAgent outriderAgent;

    void Start()
    {
        outriderAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        outriderSpeed = Random.Range(20, 30);
        outriderAgent.speed = outriderSpeed;
    }

    // Update is called once per frame
    void Update() 
    {
        outriderAgent.Move(new Vector3(-10, 10, 0) * Time.deltaTime);
        if(transform.position.x < 500) {
            Destroy(gameObject);
        }
    }

}
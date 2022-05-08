using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviathanSpawner : MonoBehaviour
{
    public GameObject leviathanPrefab;
    public int count = 5;
    float minPosX = 670f;
    float maxPosX = 690f;
    float minPosZ = 60f;
    float maxPosZ = 500f;
    float minPosY = 250f;
    float maxPosY = 320f;

    void Awake()
    {
        // Spawn Leviathan count number of times
        for(int i = 0; i < count; i++)
        {
            float x = Random.Range(minPosX, maxPosX);
            float y = Random.Range(minPosY, maxPosY);
            float z = Random.Range(minPosZ, maxPosZ);

            GameObject newLeviathan = Instantiate(leviathanPrefab, new Vector3(x, y, z), new Quaternion(0, 0, 0, 1));

            newLeviathan.AddComponent<Boid>();
            newLeviathan.AddComponent<ObstacleAvoidance>();
            NoiseWander vertical = newLeviathan.AddComponent<NoiseWander>();
            newLeviathan.AddComponent<NoiseWander>();
            newLeviathan.AddComponent<SpineAnimator>();

            vertical.axis = NoiseWander.Axis.Vertical;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

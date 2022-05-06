using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipISpawner : MonoBehaviour
{
    public GameObject ShipIPrefab;
    public int count = 5;

    float minPosX = 600f;
    float maxPosX = 900f;
    float minPosZ = 400f;
    float maxPosZ = 20f;
    float minPosY = 200f;
    float maxPosY = 400f;

    void Awake()
    {
        // Spawn ThanosShipI count number of times
        for(int i = 0; i < count; i++)
        {
            float x = Random.Range(minPosX, maxPosX);
            float y = Random.Range(minPosY, maxPosY);
            float z = Random.Range(minPosZ, maxPosZ);

            GameObject newShipI = Instantiate(ShipIPrefab, new Vector3(x, y, z), new Quaternion(-1f, 0, 0, 1));

            newShipI.AddComponent<Boid>();
            newShipI.AddComponent<Arrive>();
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

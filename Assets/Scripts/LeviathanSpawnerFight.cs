using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviathanSpawnerFight : MonoBehaviour
{
    public GameObject leviathanPrefab;
    public int count = 10;
    float minPosX = 650f;
    float maxPosX = 850f;
    float minPosZ = 60f;
    float maxPosZ = 400f;
    float minPosY = 200f;
    float maxPosY = 300f;

    void Awake()
    {
        // Spawn Leviathan count number of times
        for(int i = 0; i < count; i++)
        {
            float x = Random.Range(minPosX, maxPosX);
            float y = Random.Range(minPosY, maxPosY);
            float z = Random.Range(minPosZ, maxPosZ);

            GameObject newLeviathan = Instantiate(leviathanPrefab, new Vector3(x, y, z), new Quaternion(0, -1, 0, 1));

            Boid boid = newLeviathan.transform.GetChild(0).gameObject.GetComponent<Boid>();
            LeviathanFight leviathanFight = newLeviathan.transform.GetChild(0).gameObject.AddComponent<LeviathanFight>();
            Seek seek = newLeviathan.transform.GetChild(0).gameObject.GetComponent<Seek>();
            NoiseWander vertical = newLeviathan.transform.GetChild(0).gameObject.AddComponent<NoiseWander>();
            NoiseWander horizontal = newLeviathan.transform.GetChild(0).gameObject.AddComponent<NoiseWander>();

            seek.target = new Vector3(300, newLeviathan.transform.position.y, newLeviathan.transform.position.z);

            float verticalFrequency = Random.Range(0.05f, 0.15f);
            float verticalAmplitude = Random.Range(170f, 190f);
            float horizontalFrequency = Random.Range(0.025f, 0.075f);
            float horizontalAmplitude = Random.Range(110f, 130f);

            vertical.axis = NoiseWander.Axis.Vertical;
            vertical.frequency = verticalFrequency;
            vertical.amplitude = verticalAmplitude;
            vertical.radius = 30f;
            vertical.distance = 20;

            horizontal.frequency = horizontalFrequency;
            horizontal.amplitude = horizontalAmplitude;
            horizontal.radius = 20f;
            horizontal.distance = 20f;

            leviathanFight.avengerShipMask = LayerMask.GetMask("AvengerShip");

            boid.maxSpeed = 20f;
            boid.maxForce = 30f;
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

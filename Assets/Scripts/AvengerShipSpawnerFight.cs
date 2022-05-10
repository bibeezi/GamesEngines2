using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvengerShipSpawnerFight : MonoBehaviour
{   
    int avengerShipICount = 0;
    int avengerShipIICount = 0;
    public GameObject avengerShipI;
    public GameObject avengerShipII;
    public GameObject bulletPrefab;
    float minPosX = 170f;
    float maxPosX = 300f;
    float minPosZ = 60f;
    float maxPosZ = 400f;
    float minPosY = 60f;
    float maxPosY = 100f;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        avengerShipICount = PlayerPrefs.GetInt("avengerShipICount");
        avengerShipIICount = PlayerPrefs.GetInt("avengerShipIICount");

        for(int i = 0; i < avengerShipICount; i++)
        {
            float x = Random.Range(minPosX, maxPosX);
            float y = Random.Range(minPosY, maxPosY);
            float z = Random.Range(minPosZ, maxPosZ);

            GameObject newAvengerShipI = Instantiate(avengerShipI, new Vector3(x, y, z), new Quaternion(0, 1, 0, 1));

            newAvengerShipI.layer = LayerMask.NameToLayer("AvengerShip");
            AvengerShipFight avengerShipFight = newAvengerShipI.AddComponent<AvengerShipFight>();
            newAvengerShipI.AddComponent<StateMachine>();
            Boid boid = newAvengerShipI.AddComponent<Boid>();
            ObstacleAvoidance obstacleAvoidance = newAvengerShipI.AddComponent<ObstacleAvoidance>();
            newAvengerShipI.AddComponent<Flee>();
            newAvengerShipI.AddComponent<Pursue>();

            avengerShipFight.bulletPrefab = bulletPrefab;
            
            obstacleAvoidance.mask = obstacleAvoidance.mask & ~LayerMask.GetMask("Bullet");
            obstacleAvoidance.forwardFeelerDepth = 50f;
            obstacleAvoidance.sideFeelerDepth = 20f;
            obstacleAvoidance.weight = 10f;

            boid.maxSpeed = 30f;
            boid.maxForce = 40f;
        }
        
        for(int i = 0; i < avengerShipIICount; i++)
        {
            float x = Random.Range(minPosX, maxPosX);
            float y = Random.Range(minPosY, maxPosY);
            float z = Random.Range(minPosZ, maxPosZ);

            GameObject newAvengerShipII = Instantiate(avengerShipII, new Vector3(x, y, z), new Quaternion(0, 1, 0, 1));
            
            newAvengerShipII.layer = LayerMask.NameToLayer("AvengerShip");
            AvengerShipFight avengerShipFight = newAvengerShipII.AddComponent<AvengerShipFight>();
            newAvengerShipII.AddComponent<StateMachine>();
            Boid boid = newAvengerShipII.AddComponent<Boid>();
            ObstacleAvoidance obstacleAvoidance = newAvengerShipII.AddComponent<ObstacleAvoidance>();
            newAvengerShipII.AddComponent<Flee>();
            newAvengerShipII.AddComponent<Pursue>();

            avengerShipFight.bulletPrefab = bulletPrefab;

            obstacleAvoidance.mask = obstacleAvoidance.mask & ~LayerMask.GetMask("Bullet");
            obstacleAvoidance.forwardFeelerDepth = 50f;
            obstacleAvoidance.sideFeelerDepth = 20f;
            obstacleAvoidance.weight = 10f;

            boid.maxSpeed = 30f;
            boid.maxForce = 40f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

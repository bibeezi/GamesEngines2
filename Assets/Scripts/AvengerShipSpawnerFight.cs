using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvengerShipSpawnerFight : MonoBehaviour
{   
    int avengerShipICount = 0;
    int avengerShipIICount = 0;
    public GameObject avengerShipI;
    public GameObject avengerShipII;
    float minPosX = 170f;
    float maxPosX = 300f;
    float minPosZ = 60f;
    float maxPosZ = 400f;
    float minPosY = 60f;
    float maxPosY = 100f;
    GameObject[] leviathans;
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        avengerShipICount = PlayerPrefs.GetInt("avengerShipICount");
        avengerShipIICount = PlayerPrefs.GetInt("avengerShipIICount");
        leviathans = GameObject.FindGameObjectsWithTag("leviathan");

        for(int i = 0; i < avengerShipICount; i++)
        {
            float x = Random.Range(minPosX, maxPosX);
            float y = Random.Range(minPosY, maxPosY);
            float z = Random.Range(minPosZ, maxPosZ);

            int whichLeviathan = Random.Range(0, leviathans.Length);
            GameObject pursueLeviathan = leviathans[whichLeviathan].transform.GetChild(0).gameObject;

            GameObject newAvengerShipI = Instantiate(avengerShipI, new Vector3(x, y, z), new Quaternion(0, 1, 0, 1));

            newAvengerShipI.layer = LayerMask.NameToLayer("AvengerShip");
            newAvengerShipI.AddComponent<AvengerShip>();
            Boid boid = newAvengerShipI.AddComponent<Boid>();
            ObstacleAvoidance obstacleAvoidance = newAvengerShipI.AddComponent<ObstacleAvoidance>();
            Flee flee = newAvengerShipI.AddComponent<Flee>();
            Pursue pursue = newAvengerShipI.AddComponent<Pursue>();
            
            pursue.target = pursueLeviathan.GetComponent<Boid>();

            obstacleAvoidance.forwardFeelerDepth = 50f;
            obstacleAvoidance.sideFeelerDepth = 20f;
            obstacleAvoidance.weight = 10f;

            flee.enabled = false;

            boid.maxSpeed = 20f;
            boid.maxForce = 30f;
        }
        
        for(int i = 0; i < avengerShipIICount; i++)
        {
            float x = Random.Range(minPosX, maxPosX);
            float y = Random.Range(minPosY, maxPosY);
            float z = Random.Range(minPosZ, maxPosZ);
            
            int whichLeviathan = Random.Range(0, leviathans.Length);
            GameObject pursueLeviathan = leviathans[whichLeviathan].transform.GetChild(0).gameObject;

            GameObject newAvengerShipII = Instantiate(avengerShipII, new Vector3(x, y, z), new Quaternion(0, 1, 0, 1));
            
            newAvengerShipII.layer = LayerMask.NameToLayer("AvengerShip");
            newAvengerShipII.AddComponent<AvengerShip>();
            Boid boid = newAvengerShipII.AddComponent<Boid>();
            ObstacleAvoidance obstacleAvoidance = newAvengerShipII.AddComponent<ObstacleAvoidance>();
            Flee flee = newAvengerShipII.AddComponent<Flee>();
            Pursue pursue = newAvengerShipII.AddComponent<Pursue>();

            pursue.target = pursueLeviathan.GetComponent<Boid>();

            obstacleAvoidance.forwardFeelerDepth = 50f;
            obstacleAvoidance.sideFeelerDepth = 20f;
            obstacleAvoidance.weight = 10f;

            flee.enabled = false;

            boid.maxSpeed = 20f;
            boid.maxForce = 30f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

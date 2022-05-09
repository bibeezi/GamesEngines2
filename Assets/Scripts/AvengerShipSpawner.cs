using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvengerShipSpawner : MonoBehaviour
{
    public GameObject avengerShipI;
    public GameObject avengerShipII;
    public GameObject[] portals;
    public int count = 6;
    GameObject newAvengerShip;

    // Start is called before the first frame update
    void Start()
    {
        portals = GameObject.FindGameObjectsWithTag("portal");

        // Spawn Avenger Ships count number of times
        // behind the portal door
        foreach(GameObject portal in portals)
        {
            int whichShip = Random.Range(0, 2);

            if(whichShip == 1)
            {
                newAvengerShip = Instantiate(avengerShipII, portal.transform.position - (transform.right * 10), new Quaternion(0, 1, 0, 1));
            }
            else
            {
                newAvengerShip = Instantiate(avengerShipI, portal.transform.position - (transform.right * 10), new Quaternion(0, 1, 0, 1));
            }

            newAvengerShip.AddComponent<AlphaChange>();
            Boid boid = newAvengerShip.AddComponent<Boid>();
            newAvengerShip.AddComponent<ObstacleAvoidance>();
            newAvengerShip.AddComponent<Pursue>();
            newAvengerShip.AddComponent<Flee>();

            boid.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

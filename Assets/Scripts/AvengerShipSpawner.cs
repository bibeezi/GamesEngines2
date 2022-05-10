using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvengerShipSpawner : MonoBehaviour
{
    public GameObject avengerShipI;
    public GameObject avengerShipII;
    public GameObject[] portals;
    GameObject newAvengerShip;
    int avengerShipICount = 0;
    int avengerShipIICount = 0;
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
                
                avengerShipIICount++;
            }
            else
            {
                newAvengerShip = Instantiate(avengerShipI, portal.transform.position - (transform.right * 10), new Quaternion(0, 1, 0, 1));

                avengerShipICount++;
            }

            newAvengerShip.AddComponent<AlphaChange>();
            newAvengerShip.AddComponent<AvengerShip>();
            Rigidbody rigidbody = newAvengerShip.AddComponent<Rigidbody>();
            
            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;
        }

        PlayerPrefs.SetInt("avengerShipICount", avengerShipICount);
        PlayerPrefs.SetInt("avengerShipIICount", avengerShipIICount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviathanFight : MonoBehaviour
{   
    public LayerMask avengerShipMask;
    Pursue pursue;
    GameObject closestAvengerShip;
    GameObject pursueAvengerShip;
    GameObject[] avengerShips;
    int whichAvengerShip;
    public int health = 5;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        pursue = GetComponent<Pursue>();
    }

    // Update is called once per frame
    void Update()
    {   
        avengerShips = FindGameObjectsWithLayer();

        if(avengerShips != null && pursue.target == null)
        {
            whichAvengerShip = Random.Range(0, avengerShips.Length);
            pursueAvengerShip = avengerShips[whichAvengerShip];
            pursue.target = pursueAvengerShip.GetComponent<Boid>();
            pursue.enabled = true;
        }

        Collider[] visibleAvengerShips = Physics.OverlapSphere(transform.position, 100f, avengerShipMask);

        if(visibleAvengerShips.Length > 0)
        {
            for(int i = 0; i < visibleAvengerShips.Length; i++)
            {
                if(closestAvengerShip == null)
                {
                    closestAvengerShip = visibleAvengerShips[i].gameObject;
                    pursue.target = closestAvengerShip.GetComponent<Boid>();
                }
                else if(Vector3.Distance(transform.position, visibleAvengerShips[i].gameObject.transform.position) < Vector3.Distance(transform.position, closestAvengerShip.transform.position))
                {
                    closestAvengerShip = visibleAvengerShips[i].gameObject;
                    pursue.target = closestAvengerShip.GetComponent<Boid>();
                }
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "bullet")
        {
            Destroy(collider.gameObject);

            health--;

            if(health == 0)
            {
                Destroy(transform.parent.gameObject);
            }
        }
        
        if(collider.tag == "avengershipI" || collider.tag == "avengershipII")
        {
            pursue.enabled = false;
            pursueAvengerShip = null;
            pursue.target = null;

            GameObject[] leviathans = GameObject.FindGameObjectsWithTag("leviathan");

            foreach(GameObject leviathan in leviathans)
            {
                if(leviathan.transform.GetChild(0).GetComponent<LeviathanFight>().pursueAvengerShip == collider.gameObject)
                {
                    // avengerShips = FindGameObjectsWithLayer();
                    // whichAvengerShip = Random.Range(0, avengerShips.Length);
                    // pursueAvengerShip = avengerShips[whichAvengerShip];
                    // pursue.target = pursueAvengerShip.GetComponent<Boid>();

                    leviathan.transform.GetChild(0).GetComponent<Pursue>().enabled = false;
                    leviathan.transform.GetChild(0).GetComponent<LeviathanFight>().pursueAvengerShip = null;
                    leviathan.transform.GetChild(0).GetComponent<LeviathanFight>().pursue.target = null;
                }
            }

                // Destroy(collider.gameObject);
            collider.gameObject.layer = 0;
            collider.gameObject.SetActive(false);
        }
    }

    GameObject[] FindGameObjectsWithLayer()
    {
        var goArray = FindObjectsOfType<GameObject>();

        var goList = new System.Collections.Generic.List<GameObject>();

        for (int i = 0; i < goArray.Length; i++) {
            if (goArray[i].layer == 7) {
                goList.Add(goArray[i]);
            }
        }

        if (goList.Count == 0) {
            return null;
        }

        return goList.ToArray();
    }
}

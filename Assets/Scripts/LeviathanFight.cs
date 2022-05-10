using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviathanFight : MonoBehaviour
{   
    public LayerMask avengerShipMask;
    Seek seek;
    GameObject closestAvengerShip;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        seek = GetComponent<Seek>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] visibleAvengerShips = Physics.OverlapSphere(transform.position, 100f, avengerShipMask);

        if(visibleAvengerShips.Length > 0)
        {
            seek.enabled = true;
            
            for(int i = 0; i < visibleAvengerShips.Length; i++)
            {
                if(closestAvengerShip == null)
                {
                    closestAvengerShip = visibleAvengerShips[i].gameObject;
                    seek.target = closestAvengerShip.transform.position;
                }
                else if(Vector3.Distance(transform.position, visibleAvengerShips[i].gameObject.transform.position) < Vector3.Distance(transform.position, closestAvengerShip.transform.position))
                {
                    closestAvengerShip = visibleAvengerShips[i].gameObject;
                    seek.target = closestAvengerShip.transform.position;
                }
            }
        }
        else
        {
            seek.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipILand : MonoBehaviour
{
    RaycastHit hit;
    LayerMask land;
    ShipIArrive shipIArrive;
    ShipIBoid shipIBoid;
    public GameObject outriderPrefab;
    public int outriderCount = 10;
    bool landing = true;
    bool releaseOutriders = false;
    public int outriderSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        land = ~land;
        shipIArrive = GetComponent<ShipIArrive>();
        shipIBoid = GetComponent<ShipIBoid>();
    }

    // Update is called once per frame
    void Update()
    {
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), out hit, 500f, land) && landing)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * hit.distance, Color.yellow);
            shipIArrive.targetPosition =  hit.point;
            shipIBoid.enabled = true;
        }

        if(Vector3.Distance(transform.position, hit.point) < 15f && releaseOutriders == false)
        {
            shipIBoid.enabled = false;
            releaseOutriders = true;
        }

        if(releaseOutriders)
        {
            for(int i = 0; i < outriderCount; i++)
            {
                GameObject newOutrider = Instantiate(outriderPrefab, transform.position, transform.rotation);

                newOutrider.transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * outriderSpeed;
            }
            releaseOutriders = false;
        }
    }
}

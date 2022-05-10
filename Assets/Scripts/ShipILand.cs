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
    public int outriderCount = 30;
    bool landing = true;
    bool releaseOutriders = false;
    bool closeShip = true;
    bool playOnce = true;

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
            landing = false;
        }

        if(Vector3.Distance(transform.position, hit.point) < 140f && playOnce)
        {
            GetComponent<AudioSource>().Play();
            playOnce = false;
        }

        if(Vector3.Distance(transform.position, hit.point) < 20f && releaseOutriders == false)
        {
            shipIBoid.enabled = false;
            releaseOutriders = true;
        }

        if(releaseOutriders && closeShip)
        {
            for(int i = 0; i < outriderCount; i++)
            {
                float x = Random.Range(-10f, 10f);
                float z = Random.Range(-10f, 10f);

                GameObject newOutrider = Instantiate(outriderPrefab, transform.position - new Vector3(x, 20, z), new Quaternion(0f, -1f, 0f, 1));

                newOutrider.AddComponent<Outrider>();
                newOutrider.AddComponent<UnityEngine.AI.NavMeshAgent>();
            }
            closeShip = false;
        }
    }
}

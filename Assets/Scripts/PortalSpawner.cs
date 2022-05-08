using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    public GameObject portalPrefab;
    public int count = 6;

    float minPosX = 260f;
    float maxPosX = 280f;
    float minPosY = 20f;
    float maxPosY = 60f;

    void Awake()
    {
        // Spawn Portals count number of times
        for(int i = 0; i < count; i++)
        {
            float x = Random.Range(minPosX, maxPosX);
            float y = Random.Range(minPosY, maxPosY);
            float z = 90 + ((300 / 6) * i);

            GameObject newPortal = Instantiate(portalPrefab, new Vector3(x, y, z), new Quaternion(1, 0, 0, 1));

            ParticleSystem particleSystem = newPortal.GetComponent<ParticleSystem>();
            var shape = particleSystem.shape;
            shape.radius = Random.Range(13f, 30f);
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

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
    float maxPosY = 200f;
    void Awake()
    {
        avengerShipICount = PlayerPrefs.GetInt("avengerShipICount");
        avengerShipIICount = PlayerPrefs.GetInt("avengerShipIICount");

        for(int i = 0; i < avengerShipICount; i++)
        {
            float x = Random.Range(minPosX, maxPosX);
            float y = Random.Range(minPosY, maxPosY);
            float z = Random.Range(minPosZ, maxPosZ);

            Instantiate(avengerShipI, new Vector3(x, y, z), new Quaternion(0, 1, 0, 1));
        }
        
        for(int i = 0; i < avengerShipIICount; i++)
        {
            float x = Random.Range(minPosX, maxPosX);
            float y = Random.Range(minPosY, maxPosY);
            float z = Random.Range(minPosZ, maxPosZ);
            
            Instantiate(avengerShipII, new Vector3(x, y, z), new Quaternion(0, 1, 0, 1));
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

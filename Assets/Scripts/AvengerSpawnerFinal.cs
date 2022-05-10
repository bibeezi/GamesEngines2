using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AvengerSpawnerFinal : MonoBehaviour
{   
    int avengerShipICount = 0;
    int avengerShipIICount = 0;
    public GameObject avengerShipI;
    public GameObject avengerShipII;
    float minPosX = 200f;
    float maxPosX = 400f;
    float minPosZ = 60f;
    float maxPosZ = 400f;
    float minPosY = 100f;
    float maxPosY = 300f;
    GameObject[] bullets;
    public GameObject bulletPrefab;

    IEnumerator ShootChargedBullets()
    {
        while(true)
        {
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("bulletCharge");
            GameObject[] avengerShips = FindGameObjectsWithLayer();

            if(avengerShips != null)
            {
                foreach(GameObject bullet in bullets)
                {
                    GameObject newBullet = Instantiate(bulletPrefab, bullet.transform.position, bullet.transform.rotation);
                    newBullet.AddComponent<ChargeBullet>();
                    Boid boid = newBullet.AddComponent<Boid>();
                    Seek seek = newBullet.AddComponent<Seek>();

                    int whichAvengerShip = Random.Range(0, avengerShips.Length);
                    GameObject seekAvengerShip = avengerShips[whichAvengerShip];
                    seek.targetGameObject = seekAvengerShip;
                    seek.enabled = true;
                }
            }

            yield return new WaitForSeconds(2f);
        }
    }

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

            newAvengerShipI.layer = 7;

            Boid boid = newAvengerShipI.AddComponent<Boid>();
            Seek seek = newAvengerShipI.AddComponent<Seek>();

            seek.target = GameObject.FindGameObjectsWithTag("sanctuary")[0].transform.position;

            boid.maxSpeed = 30f;
            boid.maxForce = 40f;
        }
        
        for(int i = 0; i < avengerShipIICount; i++)
        {
            float x = Random.Range(minPosX, maxPosX);
            float y = Random.Range(minPosY, maxPosY);
            float z = Random.Range(minPosZ, maxPosZ);

            GameObject newAvengerShipII = Instantiate(avengerShipII, new Vector3(x, y, z), new Quaternion(0, 1, 0, 1));
        
            newAvengerShipII.layer = 7;

            Boid boid = newAvengerShipII.AddComponent<Boid>();
            Seek seek = newAvengerShipII.AddComponent<Seek>();

            seek.target = GameObject.FindGameObjectsWithTag("sanctuary")[0].transform.position;
            
            boid.maxSpeed = 30f;
            boid.maxForce = 40f;
        }

        StartCoroutine("ShootChargedBullets");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");

        if(bullets.Length == 0)
        {
            SceneManager.LoadScene(sceneName: "15EndScene");
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

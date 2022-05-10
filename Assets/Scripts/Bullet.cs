using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;

    IEnumerator DestroyBullets()
    {
        yield return new WaitForSeconds(5f);

        Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine("DestroyBullets");
    }

    // Update is called once per frame
    void Update() 
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

}
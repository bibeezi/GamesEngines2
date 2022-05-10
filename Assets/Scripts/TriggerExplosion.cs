using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExplosion : MonoBehaviour
{
    public ParticleSystem explosion;
    public GameObject sanctuary;

    IEnumerator CloseApplication()
    {
        yield return new WaitForSeconds(8f);

        Instantiate(explosion, new Vector3(730, 300, 280), transform.rotation);

        sanctuary.SetActive(false);
        gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        Application.Quit();
    }

    void Start()
    {
        StartCoroutine("CloseApplication");
    }

    void Update() {
    }
}
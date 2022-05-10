using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBulletCamera : MonoBehaviour
{
    public Camera sideCamera;
    public AvengerSpawnerFinal avengerSpawnerFinal;

    IEnumerator ChangeCamera()
    {
        yield return new WaitForSeconds(6f);

        sideCamera.enabled = true;
        sideCamera.GetComponent<AudioListener>().enabled = true;
        gameObject.GetComponent<AudioListener>().enabled = false;
        gameObject.SetActive(false);

        avengerSpawnerFinal.gameObject.SetActive(true);

        yield break;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeCamera());
    }

    // Update is called once per frame
    void Update()
    {

    }
}

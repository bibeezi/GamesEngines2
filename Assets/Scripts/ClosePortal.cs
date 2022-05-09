using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePortal : MonoBehaviour
{
    public float shrinkSpeed = 5;
    bool shrink = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shrink == true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, (shrinkSpeed * Time.deltaTime) / Vector3.Distance(transform.localScale, Vector3.zero));
            transform.parent.localScale = Vector3.Lerp(transform.parent.localScale, Vector3.zero, (shrinkSpeed * Time.deltaTime) / Vector3.Distance(transform.parent.localScale, Vector3.zero));
        }

        if(transform.localScale == Vector3.zero)
        {
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        shrink = true;
    }
}

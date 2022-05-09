using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaChange : MonoBehaviour
{
    Boid boid;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            foreach(Material material in child.gameObject.GetComponent<MeshRenderer>().materials)
            {
                Color colour = material.color;

                material.color = new Color(colour.r, colour.g, colour.b, 0f);

                material.SetFloat("_Mode", 2);
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.EnableKeyword("_ALPHABLEND_ON");
                material.renderQueue = 3000;
            }
        }

        boid = gameObject.GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in transform)
        {
            foreach(Material material in child.gameObject.GetComponent<MeshRenderer>().materials)
            {
                Color colour = material.color;

                if(colour.a < 1)
                {
                    material.color = new Color(colour.r, colour.g, colour.b, colour.a + 0.001f);
                    transform.position += transform.forward * Time.deltaTime;
                }
                else {
                    boid.enabled = true;
                }
            }
        }
    }   
}

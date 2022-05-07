using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent (typeof(ShipIBoid))]
public abstract class ShipISteeringBehaviour:MonoBehaviour
{
    public float weight = 1.0f;
    public Vector3 force;

    [HideInInspector]
    public ShipIBoid shipIBoid;

    public void Awake()
    {
        shipIBoid = GetComponent<ShipIBoid>();
    }

    public abstract Vector3 Calculate();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    
    public Vector3 velocity;
    public float speed;
    public Vector3 acceleration;
    public Vector3 force;
    public float maxSpeed = 30;

    public float mass = 1;

    public float slowingDistance = 80;

    public Path path;
    public bool pathFollowingEnabled = false;
    public float waypointDistance = 3;

    public float banking = 0.1f; 

    public float damping = 0.1f;

    void Start()
    {

    }

    public Vector3 PathFollow()
    {
        Vector3 nextWaypoint = path.Next();

        if (!path.isLooped && path.IsLast())
        {
            return Arrive(nextWaypoint);
        }
        else
        {
            if (Vector3.Distance(transform.position, nextWaypoint) < waypointDistance)
            {
                path.AdvanceToNext();
            }

            return Seek(nextWaypoint);
        }
    }

    public Vector3 Seek(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        Vector3 desired = toTarget.normalized * maxSpeed;

        return (desired - velocity);
    } 

    public Vector3 Arrive(Vector3 target)
    {
       Vector3 toTarget = target - transform.position;

       float dist = toTarget.magnitude;

       if (dist == 0.0f)
       {
           return Vector3.zero;
       }

       float ramped = (dist / slowingDistance) * maxSpeed;
       float clamped = Mathf.Min(ramped, maxSpeed);

       Vector3 desired = clamped * (toTarget / dist);

       return desired - velocity;
    }

    public Vector3 CalculateForce()
    {
        Vector3 f = Vector3.zero;

        if (pathFollowingEnabled)
        {
            f += PathFollow();
        }

        return f;
    }

    void Update()
    {
        force = CalculateForce();
        acceleration = force / mass;
        velocity = velocity + acceleration * Time.deltaTime;
        transform.position = transform.position + velocity * Time.deltaTime;
        speed = velocity.magnitude;
        if (speed > 0)
        {
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + velocity, tempUp);

            velocity -= (damping * velocity * Time.deltaTime);
        }        
    }
}
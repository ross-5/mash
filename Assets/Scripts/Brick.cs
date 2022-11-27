using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints1;
    [SerializeField] private float speed;
    [SerializeField] private float checkDistance = 0.05f;
    private Transform targetWaypoint;
    private int currentWaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        targetWaypoint= waypoints1[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector3)Vector2.MoveTowards(
            current: (Vector2)transform.position,
            (Vector2)targetWaypoint.position,
            maxDistanceDelta:speed * Time.deltaTime);
        if(Vector2.Distance(a:transform.position, b:targetWaypoint.position) < checkDistance)
        {
            targetWaypoint = GetNextWaypoint();
        }
    }
    private Transform GetNextWaypoint()
    {
        currentWaypointIndex++;
        if(currentWaypointIndex >= waypoints1.Length) 
        { 
            currentWaypointIndex= 0;
        }

        return waypoints1[currentWaypointIndex];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    // end points where the platform wants to move
    [SerializeField] GameObject[] waypoints;

    // waypoint index
    int currentWaypointIndex = 0;

    // speed
    [SerializeField] float speed = 1f;

    void Update()
    {
        // checks how far we are from waypoint to current postion
        // if we reach end then change the waypoint to other direction
        if(Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        // move towards current active waypoint
        // move 1 game unit
        transform.position = Vector3.MoveTowards(transform.position, 
            waypoints[currentWaypointIndex].transform.position, 
            speed * Time.deltaTime);
    }
}

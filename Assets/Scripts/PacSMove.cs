using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacSMove : MonoBehaviour
{
    public float speed = 1f; // You can adjust the speed as needed
    private int currentWaypointIndex = 0;

    // These are your specific coordinates
    private Vector3[] waypoints = 
    {
        new Vector3(-2.25f, 2.3f, 0),
        new Vector3(-1.5f, 2.3f, 0),
        new Vector3(-1.5f, 1.7f, 0),
        new Vector3(-2.25f, 1.7f, 0)
    };

    void Start()
    {
        // Start the movement coroutine
        StartCoroutine(MoveToWaypoints());
    }

    IEnumerator MoveToWaypoints()
    {
        while (true)
        {
            // Calculate the movement direction and remaining distance
            Vector3 direction = waypoints[currentWaypointIndex] - transform.position;
            float distance = direction.magnitude;

            while (distance > 0)
            {
                // Calculate the step to move in this frame and update the position
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], step);

                // Recalculate the remaining distance
                direction = waypoints[currentWaypointIndex] - transform.position;
                distance = direction.magnitude;

                yield return null; // Wait for the next frame
            }

            // Move to the next waypoint in a loop
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

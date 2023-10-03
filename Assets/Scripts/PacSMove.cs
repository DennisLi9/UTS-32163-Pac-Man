using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacSMove : MonoBehaviour
{
    public float speed = 1f; // You can adjust the speed as needed
    private int currentWaypointIndex = 0;
    public Animator animator;  // Reference to the Animator component
    public AudioSource audioSource; // Reference to the AudioSource component
    // public float soundInterval = 0.3f;  // The interval at which the sound is played
    // private float soundTimer;  // Timer to control the sound interval
    private float distanceTraveled = 0f; // To keep track of the distance traveled
    private const float SOUND_PLAY_DISTANCE = 0.15f; // Play sound every 0.15 units distance
    private Vector3 lastPosition; 

    // These are your specific coordinates
    private Vector3[] waypoints = 
    {
        new Vector3(-1.5f, 2.3f, 0),
        new Vector3(-1.5f, 1.7f, 0),
        new Vector3(-2.25f, 1.7f, 0),
        new Vector3(-2.25f, 2.3f, 0)
    };

    void Start()
    {
        lastPosition = transform.position; // Initialize the last position
        // Start the movement coroutine
        StartCoroutine(MoveToWaypoints());
        // soundTimer = soundInterval;  // Initialize the sound timer
    }

    IEnumerator MoveToWaypoints()
    {
        while (true)
        {
            // Calculate the movement direction and remaining distance
            Vector3 direction = waypoints[currentWaypointIndex] - transform.position;
            float distance = direction.magnitude;

            // // Calculate normalized direction
            Vector3 normalizedDirection = direction.normalized;

            // Update animator parameters
            animator.SetFloat("Dir_X", normalizedDirection.x);
            animator.SetFloat("Dir_Y", normalizedDirection.y);

            // // Add these lines to log the values to the console
            // Debug.Log($"Dir_X: {normalizedDirection.x}, Dir_Y: {normalizedDirection.y}");
            
            while (distance > 0)
            {
                // Calculate the step to move in this frame and update the position
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], step);

                // soundTimer -= Time.deltaTime;  // Decrease the timer by the time passed since the last frame
                //
                // if (soundTimer <= 0f)  // When the timer reaches zero, play the sound and reset the timer
                // {
                //     audioSource.Play();
                //     soundTimer = soundInterval;
                // }
                
                // Calculate the distance traveled
                distanceTraveled += Vector3.Distance(transform.position, lastPosition);
                lastPosition = transform.position;

                // If the distance traveled is greater than the specified length, play the sound
                if (distanceTraveled >= SOUND_PLAY_DISTANCE)
                {
                    audioSource.Play();
                    distanceTraveled = 0f; // Reset the distance traveled
                }
                
                // Recalculate the remaining distance
                direction = waypoints[currentWaypointIndex] - transform.position;
                distance = direction.magnitude;
                
                yield return null; // Wait for the next frame
            }

            // audioSource.Play();  // Play the sound effect
            
            // Move to the next waypoint in a loop
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacSMove : MonoBehaviour
{
    public float speed = 1f; 
    private int currentWaypointIndex = 0;
    public Animator animator;  
    public AudioSource audioSource; 
    // public float soundInterval = 0.3f;
    // private float soundTimer; 
    private float distanceTraveled = 0f; 
    private const float SOUND_PLAY_DISTANCE = 0.15f; 
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
        lastPosition = transform.position;
        StartCoroutine(MoveToWaypoints());
        
    }

    IEnumerator MoveToWaypoints()
    {
        while (true)
        {
            Vector3 direction = waypoints[currentWaypointIndex] - transform.position;
            float distance = direction.magnitude;
            Vector3 normalizedDirection = direction.normalized;
            
            animator.SetFloat("Dir_X", normalizedDirection.x);
            animator.SetFloat("Dir_Y", normalizedDirection.y);
            // Debug.Log($"Dir_X: {normalizedDirection.x}, Dir_Y: {normalizedDirection.y}");
            
            while (distance > 0)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], step);
                // if (soundTimer <= 0f)  // When the timer reaches zero, play the sound and reset the timer
                // {
                //     audioSource.Play();
                //     soundTimer = soundInterval;
                // }
                distanceTraveled += Vector3.Distance(transform.position, lastPosition);
                lastPosition = transform.position;
                
                if (distanceTraveled >= SOUND_PLAY_DISTANCE)
                {
                    audioSource.Play();
                    distanceTraveled = 0f;
                }
                
                direction = waypoints[currentWaypointIndex] - transform.position;
                distance = direction.magnitude;
                
                yield return null; 
            }
            // audioSource.Play();
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

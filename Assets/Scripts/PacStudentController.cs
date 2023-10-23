using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float speed = 1f; // Adjust this value to control the speed of PacStudent
    public LayerMask wallLayer; // Assign the layer of the walls in the Inspector
    private Vector3 targetPosition;
    private bool isMoving;
    private Vector3 lastInput;
    private Vector3 currentInput;
    
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position; // Initialize targetPosition
        isMoving = false;
        lastInput = Vector3.zero;
        currentInput = Vector3.zero;
    }
    void GatherInput()
    {
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            input = Vector3.up;
        else if (Input.GetKey(KeyCode.A))
            input = Vector3.left;
        else if (Input.GetKey(KeyCode.S))
            input = Vector3.down;
        else if (Input.GetKey(KeyCode.D))
            input = Vector3.right;

        if (input != Vector3.zero)
            lastInput = input;
        
        if (IsWalkable(transform.position + lastInput))
        {
            currentInput = lastInput;
            targetPosition = transform.position + currentInput;
            isMoving = true;
        }
        else if (IsWalkable(transform.position + currentInput))
        {
            targetPosition = transform.position + currentInput;
            isMoving = true;
        }
    }
    bool IsWalkable(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1, wallLayer);

        // If it hits something on the wallLayer, then the direction is not walkable
        if (hit.collider != null)
            return false;
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (transform.position == targetPosition)
                isMoving = false;
        }
        else
            GatherInput();
    }
}

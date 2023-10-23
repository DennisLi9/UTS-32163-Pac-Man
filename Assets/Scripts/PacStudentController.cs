using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float speed = 1f; // Adjust this value to control the speed of PacStudent
    public LevelLoader levelGenerator;
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

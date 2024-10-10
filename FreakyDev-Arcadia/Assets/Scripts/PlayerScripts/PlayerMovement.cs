using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float tileSize = 1.0f;
    public float moveSpeed = 5.0f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            MovePlayer();
        }
        else
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && CanMove(Vector3.up))
        {
            MovePlayerTo(Vector3.up * tileSize);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && CanMove(Vector3.down))
        {
            MovePlayerTo(Vector3.down * tileSize);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && CanMove(Vector3.left))
        {
            MovePlayerTo(Vector3.left * tileSize);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && CanMove(Vector3.right))
        {
            MovePlayerTo(Vector3.right * tileSize);
        }
    }

    public void MovePlayerTo(Vector3 direction)
    {
        targetPosition += direction;
        isMoving = true;
    }

    void MovePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    bool CanMove(Vector3 direction)
    {
        // Check for collision in the target direction
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, tileSize);
        return hit.collider == null; // Can move if there's no hit
    }
}





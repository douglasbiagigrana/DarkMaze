using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 pendingForce;

    public float speed = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(pendingForce * speed);

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().RestartGame();
        }
    }
    
    void OnMove(InputValue movementValue)
    {
        var movement = movementValue.Get<Vector2>();
        pendingForce = new Vector3(movement.x, 0f, movement.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_PlayerScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 MoveDirection;

    void Start()
    {
        Debug.Log("Start");
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        MoveDirection = new Vector2 (moveX, moveY).normalized; 
    }

    private void Move()
    {
        rb.velocity = new Vector2(MoveDirection.x * moveSpeed, MoveDirection.y * moveSpeed);
    }

    public void OnBeforeTransformParentChanged()
    {
        rb.transform.parent = transform;
    }
}

using UnityEngine;

public class S_PlayerScript : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;

    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 MoveDirection;

    void Start()
    {
         
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

        MoveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector2(MoveDirection.x * moveSpeed, MoveDirection.y * moveSpeed);
    }

    public void TPRoom(Vector2 pos)
    {
        transform.position = pos;
        m_Camera.transform.position = new Vector3(pos.x, pos.y, -10);
    }
}

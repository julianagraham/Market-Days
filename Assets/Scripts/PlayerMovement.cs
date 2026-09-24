using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float moveSpeed =6f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    public Vector2 lastDirection = Vector2.down;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetBool("IsMoving", movement != Vector2.zero);

        if (movement != Vector2.zero)
        {
            lastDirection = movement.normalized;

            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}

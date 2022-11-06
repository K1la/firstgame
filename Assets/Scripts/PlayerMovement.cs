using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Joystick joystick;

    public Rigidbody2D rb;
    public Animator animator;       

    Vector2 movement;
    
    private void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

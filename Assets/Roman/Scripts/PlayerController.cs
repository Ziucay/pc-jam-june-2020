using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    private bool isTouchingGround;
    private Animator playerAnimation;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        
        movement = Input.GetAxis("Vertical");
        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, movement * speed);
        }
        else if (movement < 0f)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, movement * speed);
        }
    }
}
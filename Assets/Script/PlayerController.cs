using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private string direction;
    private bool jump = false;
    private bool isJumping = false;

    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float jumpForce = 7f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            direction = "left";
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction = "right";
        }
        else
        {
            direction = null;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            jump = true;
        }

    }

    private void FixedUpdate()
    {
        if (direction == "right")
        {
            rb.AddForce(new Vector2(movementSpeed, 0), ForceMode2D.Impulse);
        }
        else if (direction == "left")
        {
            rb.AddForce(new Vector2(-movementSpeed, 0), ForceMode2D.Impulse);
        }
        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            AudioManager.instance.PlayCoinSound();
            GameManager.Instance.AddPoint();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isJumping = false;
    }
}
}

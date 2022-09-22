using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : SingletonMonoBehavior<Player>
{
    [SerializeField] private float jumpForce = 300.0f;
    [SerializeField] private float speed = 2.0f;
    private Vector3 velocity = Vector3.right;
    private Rigidbody2D rigidBody2D = new Rigidbody2D();
    private SpriteRenderer spriteRenderer = new SpriteRenderer();

    protected override void Awake()
    {
        base.Awake();
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Level.Instance.gameState == GameState.PLAYING)
        {
            ProcessInput();
            Move();
        }
    }

    private void Move()
    {
        transform.position += velocity * speed * Time.deltaTime;
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rigidBody2D.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HorizontalWall"))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            velocity = -velocity;
        }
        else if (collision.gameObject.CompareTag("Star"))
        {
            collision.gameObject.SetActive(false);
            Level.Instance.IncreasePlayerPoint();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Level.Instance.LoseGame();
        }
    }

    public void ResetPlayer()
    {
        spriteRenderer.flipX = false;
        velocity = new Vector3(1.0f, 0.0f, 0.0f);
        transform.position = new Vector3(-7.0f, 0.0f, 0.0f);
    }
}

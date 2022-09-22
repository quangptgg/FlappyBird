using UnityEngine;

public class DynamicObstacle : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float rotationSpeed = 0.1f;
    private Vector3 velocity = new Vector3(-1.0f, 0.0f, 0.0f);
    private float stickTime = 1.5f;
    private bool isStuck = false;

    void Update()
    {
        GameState gameState = Level.Instance.gameState;
        
        if (gameState == GameState.PLAYING)
        {
            stickTime -= Time.deltaTime;
            
            if (stickTime <= 0.0f)
            {
                transform.position += speed * velocity.normalized * Time.deltaTime;
                transform.Rotate(new Vector3(0.0f, 0.0f, rotationSpeed));
                isStuck = false;
            }
        }
    }

    public void ResetObstacle()
    {
        transform.position = new Vector3(6.5f, 0.0f, 0.0f);
        isStuck = false;
        stickTime = 2.0f;
        velocity = new Vector3(-1.0f, 0.0f, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float randomness = Random.Range(-1.0f, 0.0f);
        if (collision.gameObject.CompareTag("HorizontalWall"))
        {
            if (!isStuck)
            {
                velocity = new Vector3(-velocity.x, velocity.y + randomness * 0.5f, 0.0f).normalized;
                stickTime = 2.0f;
                isStuck = true;
            }
        }
        
        if (collision.gameObject.CompareTag("VerticalWall"))
        {
            if (!isStuck)
            {
                velocity = new Vector3(velocity.x + randomness * 0.5f, -velocity.y, 0.0f).normalized;
                stickTime = 2.0f;
                isStuck = true;
            }
        }
    }
}

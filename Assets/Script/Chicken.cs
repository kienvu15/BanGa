using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveX;
    [SerializeField] private float moveSpeed = 5f;

    private bool isFacingRight = true;
    [SerializeField] private ScoreManager scoreManager; // Tham chiếu đến ScoreManager

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Tìm ScoreManager nếu chưa được gắn trong Inspector
        if (scoreManager == null)
        {
            scoreManager = FindObjectOfType<ScoreManager>();
        }
    }

    private void Update()
    {
        Run();
        Flip();
    }

    private void Run()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(moveX, 0).normalized;
        rb.velocity = movement * moveSpeed;
    }

    private void Flip()
    {
        if ((moveX > 0 && !isFacingRight) || (moveX < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            Egg eggScript = collision.gameObject.GetComponent<Egg>();
            if (eggScript != null)
            {
                eggScript.SetScoreManager(scoreManager); // Gán ScoreManager
            }

            scoreManager.AddScore(1); // Tăng điểm
            Destroy(collision.gameObject); // Hủy Egg
        }
    }
}

using UnityEngine;

public class Egg : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private CircleCollider2D eggbox;

    public ScoreManager scoreManager; // Tham chiếu đến ScoreManager

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        eggbox = GetComponent<CircleCollider2D>();
    }

    // Gán ScoreManager từ bên ngoài
    public void SetScoreManager(ScoreManager manager)
    {
        scoreManager = manager;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.Play("EggCrack");
            body.gravityScale = 0;
            eggbox.enabled = false;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            scoreManager.AddScore(1); // Gọi AddScore
            Destroy(gameObject); // Hủy Egg
        }
    }

    public void Des2troy()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement; // Để load lại Scene
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas; // Canvas Game Over
    [SerializeField] private TextMeshProUGUI finalScoreText; // Text hiển thị điểm cuối cùng
    [SerializeField] private TextMeshProUGUI finalMissText; // Text hiển thị số trứng rơi

    [SerializeField] private ScoreManager scoreManager; // Tham chiếu đến script ScoreManager
    [SerializeField] private MissManager missManager; // Tham chiếu đến script MissManager

    private int maxMiss = 3; // Số lần rơi tối đa trước khi game over

    void Start()
    {
        gameOverCanvas.SetActive(false); // Ẩn Canvas Game Over khi bắt đầu
    }

    public void UpdateMiss(int currentMiss)
    {
        if (currentMiss >= maxMiss)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverCanvas.SetActive(true); // Hiện Canvas Game Over

        // Cập nhật thông tin điểm cuối cùng
        finalScoreText.text = "Final Score: " + scoreManager.GetCurrentScore().ToString();
        finalMissText.text = "Eggs Missed: " + missManager.GetCurrentMiss().ToString();

        Time.timeScale = 0; // Dừng thời gian
    }

    public void ReplayGame()
    {
        Time.timeScale = 1; // Khởi động lại thời gian
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Load lại Scene
    }
}

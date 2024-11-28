using TMPro; // Thư viện TextMeshPro
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Hiển thị điểm
    [SerializeField] private GameObject winCanvas; // Tham chiếu đến Canvas Win
    private int score = 0;
    public int targetScore = 15; // Điểm cần đạt để thắng

    private void Start()
    {
        targetScore = PlayerPrefs.GetInt("TargetScore", 15); // Lấy mục tiêu, mặc định là 15
        winCanvas.SetActive(false); // Đảm bảo Canvas ẩn khi bắt đầu
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();

        if (score >= targetScore)
        {
            ShowWinCanvas(); // Hiển thị Canvas Win
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void ShowWinCanvas()
    {
        Time.timeScale = 0f; // Dừng game
        winCanvas.SetActive(true); // Hiển thị Canvas Win
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1f; // Khôi phục tốc độ game
        PlayerPrefs.SetInt("TargetScore", 20); // Đặt mục tiêu mới là 20
        SceneManager.LoadScene("Game2"); // Chuyển sang Scene 2
    }

    public void LoadNextScene2()
    {
        Time.timeScale = 1f; // Khôi phục tốc độ game
        SceneManager.LoadScene("SampleScene"); // Chuyển sang Scene 2
    }

    public int GetCurrentScore()
    {
        return score; // Trả về điểm hiện tại
    }


}

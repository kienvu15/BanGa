using TMPro; 
using UnityEngine;

public class MissManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI missText; 
    private int miss = 0;


    public void AddMiss(int value)
    {
        miss += value;
        UpdateScoreText();

        // Kiểm tra trạng thái Game Over
        FindObjectOfType<GameManager>().UpdateMiss(miss);
    }

    public int GetCurrentMiss()
    {
        return miss; // Trả về số lần trứng rơi
    }

    private void UpdateScoreText()
    {
        missText.text = "Miss: " + miss.ToString(); 
    }
}

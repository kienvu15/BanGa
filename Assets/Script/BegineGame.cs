using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Thay "Level1" bằng tên Scene đầu tiên của bạn
    }

    public void QuitGame()
    {
        Application.Quit(); // Thoát game (chỉ hoạt động khi build game)
        Debug.Log("Game Quit!"); // Hiển thị trong Editor để kiểm tra
    }
}

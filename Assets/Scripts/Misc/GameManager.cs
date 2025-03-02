using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemiesLeft;
    [SerializeField] private GameObject winning_Game;
    private string ENEMIES_LEFT = "ENEMIES LEFT: ";
    private float current_enemiesleft = 0;
    public void AdjustEnemiesText(float num)
    {
        current_enemiesleft += num;
        enemiesLeft.text = ENEMIES_LEFT + current_enemiesleft;
        if (current_enemiesleft <= 0)
        {
            StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
            starterAssetsInputs.SetCursorState(false);
            winning_Game.SetActive(true);
        }
    }

    private void Update()
    {
    }
    public void RestartGame()
    {
        int num_Scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(num_Scene);
    }

    public void ExitGame()
    {
        Debug.Log("can not exit game in unity editor");
        Application.Quit();
    }
}

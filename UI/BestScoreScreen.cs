using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BestScoreScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI lastScoreText;
    [SerializeField] private int mainMenuScene;

    private void Start()
    {
        if (PersistanceData.bestScore < GamePlayScreen.Score)
        {
            PersistanceData.bestScore = GamePlayScreen.Score;
            PersistanceData.SaveData();
        }

        bestScoreText.text = "best score: " + PersistanceData.bestScore;
        lastScoreText.text = "your score: " + GamePlayScreen.Score;        
    }

    public void BackToMainMenuButton() => SceneManager.LoadScene(mainMenuScene);
}

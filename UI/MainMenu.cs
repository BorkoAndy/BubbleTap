using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int gameScene;
    [SerializeField] private int settingsScene;
    [SerializeField] private int bestScoreScene;

    public void GoTapButton() => SceneManager.LoadScene(gameScene);

    public void SettingsButton() => SceneManager.LoadScene(settingsScene);

    public void ScoresButton() => SceneManager.LoadScene(bestScoreScene);

    public void QuitButton() => Application.Quit();
}

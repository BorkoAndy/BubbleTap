using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LooseScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int menuScene;
    [SerializeField] private int gamePlayScene;

    private void Start() => scoreText.text = "Score " + GamePlayScreen.Score;
    public void MenuButton() => SceneManager.LoadScene(menuScene);
    public void RestartButton() => SceneManager.LoadScene(gamePlayScene);
}

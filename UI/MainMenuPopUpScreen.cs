using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPopUpScreen : MonoBehaviour
{
    [SerializeField] private int tutorialScene;

    public void YesButton() => SceneManager.LoadScene(tutorialScene);

    public void NoButton() => gameObject.SetActive(false);
}

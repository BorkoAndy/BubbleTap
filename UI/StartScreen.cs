using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    private void OnMouseDown() => SceneManager.LoadScene(1);
}

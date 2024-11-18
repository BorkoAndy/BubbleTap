using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPages : MonoBehaviour
{
    [SerializeField] private int mainMenuScene;
    [SerializeField] private GameObject[] tutorialPages;

    private int currentPage;

    private void Start()
    {
        currentPage = 0;
        foreach (var page in tutorialPages)
            page.SetActive(false);
        tutorialPages[currentPage].SetActive(true);
    }
    public void AcceptButton() => SceneManager.LoadScene(mainMenuScene);
    public void PreviousPageButton()
    {
        if (currentPage > 0)
        {
            tutorialPages[currentPage].SetActive(false);
            tutorialPages[currentPage - 1].SetActive(true);
            currentPage--;
        }
    }
    public void NextPageButton()
    {
        if (currentPage < tutorialPages.Length -1)
        {
            tutorialPages[currentPage].SetActive(false);
            tutorialPages[currentPage + 1].SetActive(true);
            currentPage++;
        }
    }
}

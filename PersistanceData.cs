using UnityEngine;

public class PersistanceData : MonoBehaviour
{
    public static bool isMusic;
    public static bool isSound;
    public static int bestScore;
  
    private void Awake()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        if (PlayerPrefs.GetInt("isMusic") == 1) isMusic = true;
        if (PlayerPrefs.GetInt("isSound") == 1) isSound = true;
    }
    public static void SaveData()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);

        if (isMusic) PlayerPrefs.SetInt("isMusic", 1);
        else PlayerPrefs.SetInt("isMusic", 0);

        if (isSound) PlayerPrefs.SetInt("isSound", 1);
        else PlayerPrefs.SetInt("isSound", 0);
    }       
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    public static Action<bool> MusicPlay;

    [SerializeField] private int mainMenuScene;
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Toggle musicToggle;

    

    private void Start()
    {
        soundToggle.isOn = !PersistanceData.isSound;
        musicToggle.isOn = !PersistanceData.isMusic;
    }
    public void BackToMainMenuButton()
    {
        PersistanceData.SaveData();
        SceneManager.LoadScene(mainMenuScene);
    }

    public void SoundChange() => PersistanceData.isSound = !soundToggle.isOn;

    public void MusicChange()
    {
        PersistanceData.isMusic = !musicToggle.isOn;
        MusicPlay?.Invoke(!musicToggle.isOn);
    }


}

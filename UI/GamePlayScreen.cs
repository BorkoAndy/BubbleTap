using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GamePlayScreen : MonoBehaviour
{
    public static int Score;
    public static Action OnLevelIncrease;

    [SerializeField] private int looseScene;
    [SerializeField] private int bubbleValue;
    [SerializeField] private TextMeshProUGUI scoreCounterText;
    [SerializeField] private TextMeshProUGUI timerText;

    private int _timerMin;
    private float _timerSec;
    
    private void OnEnable() => Bubble.OnBlow += IncreaseScore;
    private void OnDisable() => Bubble.OnBlow -= IncreaseScore;

    private void Start()
    {
        Score = 0;
        _timerMin = 3;
        _timerSec = 0;
    }
    private void Update()
    {
        _timerSec -= Time.deltaTime;
        if (_timerSec < 0)
        {
            _timerSec = 59;
            _timerMin--;
            if (_timerMin < 0) EndOfTime();
        }
        TimerTextUpdate();        
    }
    private void IncreaseScore()
    {
        Score += bubbleValue;
        scoreCounterText.text = "Score: " + Score;

        if(Score % 100 == 0) OnLevelIncrease?.Invoke();
    }
    private void EndOfTime() => SceneManager.LoadScene(looseScene);

    private void TimerTextUpdate() => timerText.text = "Time: " + _timerMin + ":" + (int)_timerSec;

    public void PauseButton()
    {
        if(Time.timeScale == 1)
            Time.timeScale = 0; 
        else Time.timeScale = 1;
    }
}

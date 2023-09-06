using UnityEngine;
using TMPro;
using System;
using Interfaces;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIElements _uiElements;
    
    private TMP_Text _botScore;
    private TMP_Text _playerScore;

    public IBotController BotController
    {
        get => _botСontroller ?? throw new ArgumentNullException("botController был null");
        set
        {
            if (_botСontroller != null) Debug.LogWarning("Попытка перезаписи botController`а");
            _botСontroller ??= value;
        }
    }
    private IBotController _botСontroller;
    
    public IClockable PlayerController
    {
        get => _playerController ?? throw new ArgumentNullException("playerController был null");
        set
        {
            if (_playerController != null) Debug.LogWarning("Попытка перезаписи botController`а");
            _playerController ??= value;
        }
    }
    private IClockable _playerController;
    
    void Start()
    {
        
        Time.timeScale = 1;
        
        _uiElements.ButtonExit.SetActive(false);
        _uiElements.ButtonRetry.SetActive(false);
        
        CheckReferences();
    }

    public void SetActiveManager(bool isActive)
    {
        this.enabled = isActive;
    }
    

    void CheckReferences()
    {
        if (_uiElements.ButtonRetry == null)
            Debug.LogError("ButtonRetry не найден");
        if (_uiElements.ButtonExit == null)
            Debug.LogError("ButtonExit не найден");
        if (_botСontroller == null)
            Debug.LogError("BallController был null");
    }
    
    private void Update()
    {
        _botСontroller.UpdateTick();
        
    }
    
    public void OnPlayerWon()
    {
        Debug.Log("Победа игрока");
        OnGameEnd();
    }

    public void OnBotWon()
    {
        Debug.Log("Победа бота");
        OnGameEnd();
    }

    private void OnGameEnd()
    {
        Score.Instance.ClearAllScore();
        Time.timeScale = 0;
        _uiElements.ButtonExit.SetActive(true);
        _uiElements.ButtonExit.SetActive(true);
    }
    
    public void OnRestartLevelButtonPressed()
    {
        RestartLevel();
    }
    
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
    
    [Serializable]
    private class UIElements
    {
        [SerializeField]
        private GameObject _buttonRetry;
        [SerializeField]
        private GameObject _buttonExit;

        public GameObject ButtonRetry => _buttonRetry;
        public GameObject ButtonExit => _buttonExit;
    }
}

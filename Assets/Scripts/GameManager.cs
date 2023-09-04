using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIElements _uiElements;
    
    [Space(10)]
    [SerializeField] 
    private int _scoreToWin = 3;
    
    [Space(10)]
    [SerializeField]
    private GameObject _ballGameObject;
    
    private BallController _ballController;
    private BotController _botController;
    
    private TMP_Text _botScore;
    private TMP_Text _playerScore;
    
    
    
    void Start()
    {
        
        Time.timeScale = 1;
        
        _uiElements.ButtonExit.SetActive(false);
        _uiElements.ButtonRetry.SetActive(false);
        
        _ballController = _ballGameObject.GetComponent<BallController>();

        CheckReferences();
    }
    

    void CheckReferences()
    {
        _botController.FixedUpdate();
        
        if (_uiElements.ButtonRetry == null)
            Debug.LogError("ButtonRetry не найден");
        if (_uiElements.ButtonExit == null)
            Debug.LogError("ButtonExit не найден");
        if (_ballGameObject == null)
            Debug.LogError("Ball не найден");
        if (_ballController == null)
            Debug.LogError("BallController был null");
    }

    void Update()
    {
        
        if((ScoreManager.GetInstance().scoreBot == _scoreToWin) || (ScoreManager.GetInstance().scorePlayer == _scoreToWin))
        {
            ScoreManager.GetInstance().ClearAllScore();
            Time.timeScale = 0;
            _uiElements.ButtonExit.SetActive(true);
            _uiElements.ButtonExit.SetActive(true);
        }
    }

    public void RestartLevel()
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

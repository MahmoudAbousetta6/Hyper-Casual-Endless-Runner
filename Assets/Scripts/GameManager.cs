using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private GameObject _moveGroundObj;
    [SerializeField] private GameObject _obstecleManagerObj;

    [SerializeField] private GameObject _startMenuPanel;
    [SerializeField] private GameObject _deathMenuPanel;
    [SerializeField] private GameObject _scorePanel;

    [SerializeField] private Transform _rightPos;
    [SerializeField] private Transform _leftPos;
    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody _playerRB;

    [SerializeField] private Text _scoreTimer;

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedDuration = 5f;

    private bool _isRight,_isGameStarted;
    private float _elapsedTime; float _score, _modifiedScore, _lastScore;

    public GameObject StartMenuPanel { get => _startMenuPanel; set => _startMenuPanel = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public float SpeedDuration { get => _speedDuration; set => _speedDuration = value; }
    public GameObject DeathMenuPanel { get => _deathMenuPanel; set => _deathMenuPanel = value; }

    void Start()
    {
        _startButton.onClick.AddListener(StartButtonClick);
        _retryButton.onClick.AddListener(RetryButtonClick);
        _exitButton.onClick.AddListener(ExitButtonClick);

        _playerRB.useGravity = false;
        _moveGroundObj.SetActive(false);
        _obstecleManagerObj.SetActive(false);
        _startMenuPanel.SetActive(true);
        _deathMenuPanel.SetActive(false);
        _scorePanel.SetActive(false);
        Speed = 0;
        if (instance == null)
        {
            instance = this;
        }
        _isGameStarted = false;
        _modifiedScore = 1f;
        _scoreTimer.text = ("0").ToString();
       
        StartCoroutine(ChangePath(0.3f));
    }

    private void Update()
    {
        UpdateScore();
        _playerRB.velocity = _playerRB.velocity;
    }

    public void TogglePath()
    {
        _isRight = !_isRight;
        if (_elapsedTime == -1)
            StartCoroutine(ChangePath(0.3f));
        else
            _elapsedTime = 0;
    }

    private void UpdateScore()
    {
        if (_isGameStarted)
        {
            _score += (Time.deltaTime * _modifiedScore);
            if (_lastScore != (int)_score)
            {
                _lastScore = (int)_score;
                _scoreTimer.text = _score.ToString("0");
            }
        }
    }

    private IEnumerator ChangePath(float duration)
    {
        _elapsedTime = 0;
        while (_elapsedTime <= duration)
        {
            _player.transform.position = _isRight ? Vector3.Lerp(_player.transform.position, _rightPos.transform.position, _elapsedTime / duration) : Vector3.Lerp(_player.transform.position, _leftPos.transform.position, _elapsedTime / duration);
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        _elapsedTime = -1;
    }

    public void StartButtonClick()
    {
        StartCoroutine(IEstartButton(1F));
    }

    private IEnumerator IEstartButton(float duration)
    {
        yield return new WaitForSeconds(duration);
        _startMenuPanel.SetActive(false);
        _scorePanel.SetActive(true);
        Speed = 10f;
        _moveGroundObj.SetActive(true);
        _obstecleManagerObj.SetActive(true);
        _playerRB.useGravity = true;
        _isGameStarted = true;
        _elapsedTime = -1;
    }

    public void RetryButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("0-Main");
    }
    public void ExitButtonClick()
    {
        Application.Quit();
    }
}

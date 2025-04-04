using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _winTextBackground;

    [SerializeField]
    private GameObject _loseTextBackground;

    public UnityEvent OnGameWin;
    public UnityEvent OnGameLoss;

    private PlayerMovement _playerMovement;
    private PlayerTimer _playerTimer;
    private PlayerScore _playerScore;
    private PlayerLives _playerLives;
    private Rigidbody _rigidBody;
    

    private bool _gameWon;
    private bool _gameLost;

    private void Start()
    {
        if (_player)
        {
            if (!_player.TryGetComponent(out _playerMovement))
                Debug.LogError("GameManager: Could not get PlayerMovement");
            if (!_player.TryGetComponent(out _playerTimer))
                Debug.LogError("GameManager: Could not get PlayerTimer");
            if (!_player.TryGetComponent(out _playerScore))
                Debug.LogError("GameManager: Could not get PlayerScore");
            if (!_player.TryGetComponent(out _playerLives))
                Debug.LogError("GameManager: Could not get PlayerLives");
            //if (!_player.TryGetComponent(out _player1TagSystem))
            //    Debug.LogError("GameManager: Could not get Player1TagSystem");
        }
        else
            Debug.LogError("GameManaged: Player not assigned!");
        if (!_winTextBackground)
            Debug.LogError("GameManager: Win Text not assigned!");
        if (!_loseTextBackground)
            Debug.LogError("GameManager: Lose Text not assigned!");
    }

    private void Update()
    {
        if (!(_playerTimer))
            return;

        if (!(_playerScore))
            return;

        if (_gameWon)
            return;

        if (_gameLost)
            return;

        // If the game object is destroyed, lose the game
        if (_playerLives.currentPlayerLives <= 0)
            Lose("You Have Lost");

        // Do the win condition here
        if (_playerScore.currentCoins >= 20)
            Win("You Have Won");

        // Lose condition
        if (_playerTimer.TimeRemaning <= 0)
            Lose("You Have Lost");
    }

    private void Win(string winText)
    {
        // Enables win screen UI and sets the text to winText
        if (_winTextBackground)
        {
            // Sets the winTextBackground image to active
            _winTextBackground.SetActive(true);
            // Goes through the component and gets the first component in that child that matches the parameters
            TextMeshProUGUI text = _winTextBackground.GetComponentInChildren<TextMeshProUGUI>(true);
            // If we did not get text make it equal to winText
            if (text)
            {
                text.text = winText;
            }
        }

        //  Turns off the components
        if (_playerMovement)
            _playerMovement.enabled = false;
        if (_playerTimer)
            _playerTimer.enabled = false;
        if (_playerScore)
            _playerScore.enabled = false;
        if (_playerLives)
            _playerLives.enabled = false;
        //if (_player1TagSystem)
        //    _player1TagSystem.enabled = false;
        if (_rigidBody)
            _rigidBody.isKinematic = true;
        
        // Only calls this function one time instead of every frame
        _gameWon = true;

        // Take all the functions plugged into the event and call them
        OnGameWin.Invoke();
    }

    private void Lose(string loseText)
    {
        // Enables lose screen UI and sets the text to loseText
        if (_loseTextBackground)
        {
            // Sets the loseTextBackground image to active
            _loseTextBackground.SetActive(true);
            // Goes through the component and gets the first component in that child that matches the parameters
            TextMeshProUGUI text = _loseTextBackground.GetComponentInChildren<TextMeshProUGUI>(true);
            // If we did not get text make it equal to loseText
            if (text)
            {
                text.text = loseText;
            }
        }

        // Turns off the components
        if (_playerMovement)
            _playerMovement.enabled = false;
        if (_playerTimer)
            _playerTimer.enabled = false;
        if (_playerScore)
            _playerScore.enabled = false;
        if (_playerLives)
            _playerLives.enabled = false;
        //if (_player1TagSystem)
        //    _player1TagSystem.enabled = false;
        if (_rigidBody)
            _rigidBody.isKinematic = true;
        // Only calls this function one time instead of every frame
        _gameLost = true;

        // Take all the functions plugged into the event and call them
        OnGameLoss.Invoke();
    }

    public void RestartGame()
    {
        // Reload the active scene
        // Build Index tellls the SceneManager what scene it is
        // Add plus 1 to the scenes to move and change scenes
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

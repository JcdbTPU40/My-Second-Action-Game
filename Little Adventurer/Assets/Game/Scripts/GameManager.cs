using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    public GameUI_Manager gameUI_manager;
    public Character playerCharacter;
    private bool gameIsOver;

    private void Awake()
    {
        playerCharacter = GameObject.FindWithTag("Player").GetComponent<Character>();
        _playerInput = playerCharacter.GetComponent<PlayerInput>(); // この行を追加
    }

    private void GameOver()
    {
        gameUI_manager.ShowGameOverUI();
    }

    public void GameIsFinished()
    {
        gameUI_manager.ShowGameIsFinishedUI();
    }

    void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        if (_playerInput.ESCKeyDown)
        {
            gameUI_manager.TogglePauseUI();
            _playerInput.ESCKeyDown = false; // フラグをクリア
        }

        if (playerCharacter.CurrentState == Character.CharacterState.Dead)
        {
            gameIsOver = true;
            GameOver();
        }
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // ゲームが一時停止している場合、時間をリセット
        SceneManager.LoadScene("MainMenu");

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}

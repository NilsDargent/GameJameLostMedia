using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static int _currentScore = 0;
    private static int _currentlife = 3;

    [SerializeField]
    private TMP_Text ScoreText;

    [SerializeField]
    private GameObject PauseMenu;

    [SerializeField]
    private GameObject GameOverMenu;
    [SerializeField]
    private GameObject ScoreMenu;
    [SerializeField]
    private PlayerController player;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ScoreText.text = _currentScore.ToString("n0");
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Pause();
        }
    }

    public void IncrementScore(int score)
    {
        _currentScore += score;
        ScoreText.text = _currentScore.ToString("n0");
    }
    public void Pause()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);

    }

    public void Quit()
    {
        _currentScore = 0;
        _currentlife = 3;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        _currentScore = 0;
        _currentlife = 3;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Death()
    {
        _currentlife--;
        print(_currentlife);
        if (_currentlife == 0) {
            player.respawn = new Vector2();
            ScoreMenu.SetActive(false);
            GameOverMenu.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
            
    }

}

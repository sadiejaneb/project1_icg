using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesCounterText;
    public int lives = 3;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make this script persistent across scenes for reload
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        // Try to find the UI elements
        FindUIElements();

        // Initialize the UI
        livesCounterText.text = "" + lives.ToString();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindUIElements();
        livesCounterText.text = "" + lives.ToString();
    }

    private void FindUIElements()
    {
        if (livesCounterText == null)
        {
            livesCounterText = GameObject.Find("LivesCounter").GetComponent<TextMeshProUGUI>();
        }

        if (winText == null)
        {
            winText = GameObject.Find("WinText").GetComponent<TextMeshProUGUI>();
        }

        if (gameOverText == null)
        {
            gameOverText = GameObject.Find("GameOverText").GetComponent<TextMeshProUGUI>();
        }

        // Hide the win and game-over messages initially
        winText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }

    public void LoseLife()
    {
        lives--;
        livesCounterText.text = "" + lives.ToString();

        if (lives <= 0)
        {
            gameOverText.gameObject.SetActive(true);
            // Implement exit game functionality here, if you want.
            Debug.Log("Game Over!");
            Invoke("QuitGame", 3f);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void WinGame()
    {
        // Show the win message
        winText.gameObject.SetActive(true);
        Debug.Log("You Win!");

        // Add a slight delay before quitting
        Invoke("QuitGame", 4f); // 4 seconds delay
    }

    void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
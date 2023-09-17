using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI winText;

    private void Start()
    {
        // Hide the win message initially
        winText.gameObject.SetActive(false);
    }

    public void WinGame()
    {
        // Show the win message
        winText.gameObject.SetActive(true);

        // Add a slight delay before quitting
        Invoke("QuitGame", 5f); // 5 seconds delay
    }

    void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
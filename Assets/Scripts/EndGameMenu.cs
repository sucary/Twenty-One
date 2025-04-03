using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private TMP_Text resultText;

    private RectTransform panelRect;

    private void Awake()
    {
        gameObject.SetActive(false);
        panelRect = GetComponent<RectTransform>();

        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
        else
            Debug.LogError("Restart Button is missing in EndGameMenu!");

        if (menuButton != null)
            menuButton.onClick.AddListener(GoToMainMenu);
        else
            Debug.LogError("Menu Button is missing in EndGameMenu!");
    }

    public void Initialize()
    {
        panelRect.anchorMin = new Vector2(0.5f, 0.5f);
        panelRect.anchorMax = new Vector2(0.5f, 0.5f);
        panelRect.pivot = new Vector2(0.5f, 0.35f);
        panelRect.anchoredPosition = Vector2.zero;
        panelRect.sizeDelta = new Vector2(300, 200);
    }

    public void ShowPanel(string gameResultText = null)
    {
        if (resultText != null && !string.IsNullOrEmpty(gameResultText))
        {
            resultText.text = gameResultText;
        }

        gameObject.SetActive(true);

        EventSystem.current.SetSelectedGameObject(restartButton.gameObject);
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game...");
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Debug.Log("Going to main menu...");
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
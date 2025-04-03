using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public int CardNumber = 12;

    [SerializeField] private TMP_InputField p1InputField;
    [SerializeField] private TMP_InputField p2InputField;
    [SerializeField] private TMP_Text cardNumberText;
    [SerializeField] private Button plusButton;
    [SerializeField] private Button minusButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Button backButton;

    private void Start()
    {
        UpdateCardNumberDisplay();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(startButton.gameObject);

        plusButton.onClick.AddListener(IncreaseCardNumber);
        minusButton.onClick.AddListener(DecreaseCardNumber);
        startButton.onClick.AddListener(StartGame);
        backButton.onClick.AddListener(GoBack);

        // Load saved player names if they exist
        string savedP1Name = PlayerPrefs.GetString("Player1Name", "");
        string savedP2Name = PlayerPrefs.GetString("Player2Name", "");

        if (!string.IsNullOrEmpty(savedP1Name))
            p1InputField.text = savedP1Name;

        if (!string.IsNullOrEmpty(savedP2Name))
            p2InputField.text = savedP2Name;
    }

    public void OnPlayer1NameChanged(string newName)
    {
        PlayerPrefs.SetString("Player1Name", newName);
        PlayerPrefs.Save();

    }

    public void OnPlayer2NameChanged(string newName)
    {
        PlayerPrefs.SetString("Player2Name", newName);
        PlayerPrefs.Save();
    }

    public void IncreaseCardNumber()
    {
        if (CardNumber < 12)
        {
            CardNumber++;
            UpdateCardNumberDisplay();
            Debug.Log("Card number increased by 1");
        }
    }

    public void DecreaseCardNumber()
    {
        if (CardNumber > 10)
        {
            CardNumber--;
            UpdateCardNumberDisplay();
            Debug.Log("Card number decreased by 1");
        }
    }

    private void UpdateCardNumberDisplay()
    {
        cardNumberText.text = CardNumber.ToString();
    }

    public void StartGame()
    {
        Debug.Log("Game started!");
        PlayerPrefs.SetString("Player1Name", string.IsNullOrEmpty(p1InputField.text) ? "Player 1" : p1InputField.text);
        PlayerPrefs.SetString("Player2Name", string.IsNullOrEmpty(p2InputField.text) ? "Player 2" : p2InputField.text);
        PlayerPrefs.SetInt("CardNumber", CardNumber);
        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }
}

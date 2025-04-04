using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Round Round;
    public Player Player1, Player2;
    public NumberPool NumberPool;

    [SerializeField] private EndGameMenu endGamePanelPrefab;
    private EndGameMenu endGamePanel;
    [SerializeField] private Button menuButton;

    private KeyboardController keyboardController;

    void InitializeGame()
    {
        Debug.Log("Game running.");

        menuButton.interactable = true;
        Canvas mainCanvas = FindObjectOfType<Canvas>();
        endGamePanel = Instantiate(endGamePanelPrefab, mainCanvas.transform);
        endGamePanel.Initialize();

        EventSystem.current.SetSelectedGameObject(menuButton.gameObject);
    }

    void Start()
    {
        InitializeGame();

        menuButton.onClick.AddListener(BackToMenu);

        // Get saved player names and card number
        string player1Name = PlayerPrefs.GetString("Player1Name", "Player 1");
        string player2Name = PlayerPrefs.GetString("Player2Name", "Player 2");
        int cardNumber = PlayerPrefs.GetInt("CardNumber", 12);

        Player1.InitializePlayer(10, player1Name);
        Player2.InitializePlayer(10, player2Name);

        NumberPool.InitializePool(cardNumber);

        keyboardController = NumberPool.gameObject.AddComponent<KeyboardController>();

        Round.InitializeRound(NumberPool, Player1, Player2);

        StartCoroutine(PlayRounds());
    }

    // Handles round iteration
    private IEnumerator PlayRounds()
    {
        while (Round.RoundNumber <= 5)
        {
            Debug.Log($"Round {Round.RoundNumber}");
            yield return Round.RunRound();

            Round.RoundNumber++;

            if (Round.RoundNumber > 5)
            {
                Debug.Log("All rounds completed");
                break;
            }
        }
        yield return new WaitForSeconds(0.2f);
        EndGame();
    }

    private bool PlayersBusted()
    {
        return Player1.IsBusted() || Player2.IsBusted();
    }

    private void EndGame()
    {
        menuButton.interactable = false;
        NumberPool.DisableAllCards();
        string resultText = JudgeGameResult();

        Round.SetGameResultText(resultText);

        if (endGamePanel != null)
        {
            Debug.Log("Showing end game panel");
            endGamePanel.ShowPanel(resultText);

            if (keyboardController != null)
            {
                keyboardController.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("End Game Panel reference missing!");
        }


        // Announce the winner
        Debug.Log("Winner announcement text: " + Round.RoundNumber.ToString());
        UAP_AccessibilityManager.Say(Round.turnText.text, true);
    }

    // Determinate game winner based on final points
    private string JudgeGameResult()
    {
        string resultText;

        if (PlayersBusted())
        {
            if (Player1.IsBusted() && Player2.IsBusted())
            {
                resultText = "Both players busted! Game over!";
            }
            else
            {
                string winner = Player1.IsBusted() ? Player2.Name : Player1.Name;
                string loser = Player1.IsBusted() ? Player1.Name : Player2.Name;
                resultText = $"{loser} busted! {winner} wins!";
            }
        }
        else
        {
            if (Player1.Points == Player2.Points)
            {
                resultText = "Game is a tie!";
            }
            else
            {
                string winner = Player1.Points > Player2.Points ? Player1.Name : Player2.Name;
                resultText = $"{winner} won!";
            }
        }
        Debug.Log(resultText);
        return resultText;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
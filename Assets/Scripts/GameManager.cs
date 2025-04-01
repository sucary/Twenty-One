using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Round Round;
    public Player Player1, Player2;
    public NumberPool NumberPool;

    [SerializeField] private EndGameMenu endGamePanelPrefab;
    private EndGameMenu endGamePanel;
    [SerializeField] private Button menuButton;

    void InitializeGame()
    {
        Debug.Log("Game running.");

        menuButton.interactable = true;
        Canvas mainCanvas = FindObjectOfType<Canvas>();
        endGamePanel = Instantiate(endGamePanelPrefab, mainCanvas.transform);
        endGamePanel.Initialize();
    }

    void Start()
    {
        InitializeGame();
        Round.InitializeRound(NumberPool, Player1, Player2);
        NumberPool.InitializePool();
        Player1.InitializePlayer(10, "player1");
        Player2.InitializePlayer(10, "player2");

        StartCoroutine(PlayRounds());
    }

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
        }
        else
        {
            Debug.LogError("End Game Panel reference missing!");
        }
    }

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
                string winner = Player1.IsBusted() ? Player2.name : Player1.name;
                string loser = Player1.IsBusted() ? Player1.name : Player2.name;
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
                string winner = Player1.Points > Player2.Points ? Player1.name : Player2.name;
                resultText = $"{winner} won!";
            }
        }
        Debug.Log(resultText);
        return resultText;
    }
}
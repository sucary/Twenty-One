using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Round : MonoBehaviour
{
    public int RoundNumber;
    public NumberCard P1Card;
    public NumberCard P2Card;
    public int P1Result;
    public int P2Result;

    private bool _isRoundFinished;
    private NumberPool _numberPool;
    private Player _player1, _player2;

    private bool _isPlayer1Turn;

    [SerializeField] private TMP_Text roundNumberText;
    [SerializeField] private TMP_Text p1ResultText;
    [SerializeField] private TMP_Text p2ResultText;

    public void InitializeRound(NumberPool pool, Player p1, Player p2)
    {
        RoundNumber = 1;
        _isRoundFinished = false;
        _numberPool = pool;
        _player1 = p1;
        _player2 = p2;
        _isPlayer1Turn = true;
    }


    public IEnumerator RunRound()
    {
        UpdateRoundUI();

        // Wait for Player 1 to select a card
        yield return SelectCard(true);
        // Wait for Player 2 to select a card
        yield return SelectCard(false);

        // Calculate and allocate result for each player
        HandleResult(P1Card.CardValue, P2Card.CardValue);

        _isRoundFinished = true;
    }

    private IEnumerator SelectCard(bool isPlayer1)
    {
        NumberCard selectedCard = null;

        // Attach OnCardSelected listener to each card
        foreach (var card in _numberPool.NumberArray)
        {
            card.OnCardSelected += (card) =>
            {
                if ((isPlayer1 && _isPlayer1Turn) || (!isPlayer1 && !_isPlayer1Turn))
                {
                    selectedCard = card;
                }
            };
        }

        // Wait until a card is selected
        yield return new WaitUntil(() => selectedCard != null);

        if (isPlayer1)
        {
            P1Card = selectedCard;
            _isPlayer1Turn = false;
        }
        else
        {
            P2Card = selectedCard;
            _isPlayer1Turn = true;
        }

        // Remove the selected card from the pool
        _numberPool.MarkSelected(selectedCard);
    }

    private void HandleResult(int cardValue1, int cardValue2)
    {
        int result = cardValue1 - cardValue2;
        P1Result = result;
        P2Result = -result;

        p1ResultText.text = P1Result.ToString();
        p2ResultText.text = P2Result.ToString();

        _player1.AddToPoints(P1Result);
        _player2.AddToPoints(P2Result);
    }

    private void UpdateRoundUI()
    {
        roundNumberText.text = $"Round {RoundNumber}";
    }

}
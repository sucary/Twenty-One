using System.Collections;
using System.Collections.Generic;
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

    public void InitializeRound(NumberPool pool, Player p1, Player p2)
    {
        RoundNumber = 1;
        _isRoundFinished = false;
        _numberPool = pool;
        _player1 = p1;
        _player2 = p2;
    }


    public void RunRound()
    {
        // Players take turn drawing cards
        P1Card = DrawCard();
        P2Card = DrawCard();

        // Calculate result for each player
        int result = P1Card.CardValue - P2Card.CardValue;
        P1Result = result;
        P2Result = -result;

        // Add result to each player's total points
        _player1.AddToPoints(P1Result);
        _player2.AddToPoints(P2Result);

        _isRoundFinished = true;
    }

    /*
     * Now it assumes drawing the first card from the number pool.
     * TODO: add card selection
     */
    private NumberCard DrawCard()
    {
        NumberCard card = _numberPool.NumberArray[0];
        _numberPool.SelectCard(card);
        return card;
    }
}

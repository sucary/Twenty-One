using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Round Round;
    public Player Player1, Player2;
    public NumberPool NumberPool;

    void InitializeGame()
    {
        Debug.Log("Game running.");
    }

    // Start is called before the first frame update

    // TODO: Adjust starting points
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
        while (Round.RoundNumber <= 5 && !PlayersBusted())
        {
            yield return Round.RunRound();
            Round.RoundNumber++;
        }
    }

    private bool PlayersBusted()
    {
        return Player1.IsBusted() || Player2.IsBusted();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int Round;

    public Player Player1, Player2;
    public NumberPool NumberPool;

    void InitializeGame()
    {
        Debug.Log("Game running.");
        Round = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeGame();
        NumberPool.InitializePool();
        Player1.InitializePlayer();
        Player2.InitializePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

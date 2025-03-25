using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int round;


    public Player player1, player2;
    public NumberPool numberPool;

    void initializeGame()
    {
        numberPool.InitializePool();
        round = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int points;
    // string name;


    /*
     * May adjust initial points for multi-difficulty
     */ 
    public void initializePlayer()
    {
        points = 10;
    }


    public void drawCard(NumberCard card)
    {
        points += card.cardValue;
        card.OnCardDrawn();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Points   { get; private set; }
    // string name;


    /*
     * May adjust initial points for multi-difficulty, see GameManager
     */
    public void InitializePlayer(int startingPoints)
    {
        Points = startingPoints;
    }


    public void AddToPoints(int value)
    {
        Points += value;
    }

    public bool IsBusted()
    {
        return Points > 21;
    }
}

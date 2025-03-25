using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Points;
    // string name;


    /*
     * May adjust initial points for multi-difficulty
     */ 
    public void InitializePlayer()
    {
        Points = 10;
    }


    public void AddToPoints(int value)
    {
        Points += value;
    }
}

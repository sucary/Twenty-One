using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberPool : MonoBehaviour
{
    public List<NumberCard> NumberArray { get; private set; } = new List<NumberCard>();
    public List<NumberCard> DrawnNumbers { get; private set; } = new List<NumberCard>();


    public void InitializePool()
    {
        // Create the number cards (1-9)
        for (int i = 1; i <= 9; i++)
        {
            NumberArray.Add(CreateNumberCard(i));
        }
    }

    private NumberCard CreateNumberCard(int value)
    {
        return ;
    }
}
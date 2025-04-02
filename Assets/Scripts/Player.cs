using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name { get; private set; }
    public int Points   { get; private set; }

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text pointsText;

    public void InitializePlayer(int startingPoints, string playerName)
    {
        Points = startingPoints;
        Name = playerName;  // Name property
        name = playerName;  // GameObject name
        nameText.text = playerName;
        UpdatePointsUI();
    }


    public void AddToPoints(int value)
    {
        int previousPoints = Points;
        Points = previousPoints + value;
        Debug.Log($"{nameText.text}: {previousPoints} + {value} = {Points}");
        UpdatePointsUI();
    }

    private void UpdatePointsUI()
    {
        pointsText.text = Points.ToString();
    }

    public bool IsBusted()
    {
        return Points > 21;
    }
}

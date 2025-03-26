using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberPool : MonoBehaviour
{
    public List<NumberCard> NumberArray { get; private set; } = new List<NumberCard>();
    public List<NumberCard> DrawnNumbers { get; private set; } = new List<NumberCard>();

    [SerializeField] private NumberCard numberCardPrefab;

    public void InitializePool()
    {
        /*
         * Create the number cards (1-9)
         * TODO: add more numbers (or option to adjust numbers in the main menu)
         */
        for (int i = 1; i <= 9; i++)
        {
            NumberArray.Add(CreateNumberCard(i, NumberArray.Count));
            
        }
    }

    private NumberCard CreateNumberCard(int value, int cardIndex)
    {
        NumberCard newCard = Instantiate(numberCardPrefab, transform);
        newCard.Initialize(value);

        // Calculate row
        int row = cardIndex / 6;
        int column = cardIndex % 6;

        // Calculate X and Y positions
        float xPos = (column) * 102 - 258;
        float yPos = (row == 0) ? 15f : -30f;

        // Set position
        RectTransform rectTransform = newCard.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(xPos, yPos);
        Debug.Log($"Card {value} created at ({xPos}, {yPos})");

        return newCard;
    }

    public void SelectCard(NumberCard card)
    {
        card.OnCardDrawn();
        DrawnNumbers.Add(card);
        NumberArray.Remove(card);
    }
}
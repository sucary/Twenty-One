using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberPool : MonoBehaviour
{
    public List<NumberCard> NumberArray { get; private set; } = new List<NumberCard>();
    public List<NumberCard> DrawnNumbers { get; private set; } = new List<NumberCard>();

    [SerializeField] private NumberCard numberCardPrefab;


    public void InitializePool(int cardNumber)
    {
        for (int i = 1; i <= 9; i++)
        {
            NumberArray.Add(CreateNumberCard(i, NumberArray.Count));
        }

        int additionalCards = cardNumber - 9;
        for (int i = 0; i < additionalCards; i++)
        {
            int randomValue = Random.Range(1, 9);
            NumberArray.Add(CreateNumberCard(randomValue, NumberArray.Count));
        }
    }

    private NumberCard CreateNumberCard(int value, int cardIndex)
    {
        NumberCard newCard = Instantiate(numberCardPrefab, transform);
        newCard.Initialize(value);

        // Calculate row and column
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

    public void MarkSelected(NumberCard card)
    {
        if (!card.IsDrawn)
        {
            card.button.interactable = false;
            card.IsDrawn = true;
        }
        DrawnNumbers.Add(card);
        NumberArray.Remove(card);
    }

    // Disable all remaining cards when finishing the game
    public void DisableAllCards()
    {
        foreach (var card in NumberArray)
        {
            if (card != null && card.button != null)
            {
                card.button.interactable = false;
            }
        }
    }
}
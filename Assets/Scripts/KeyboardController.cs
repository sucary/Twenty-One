using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Handles keyboard navigation of [[number cards]] only!
public class KeyboardController : MonoBehaviour
{
    private List<NumberCard> cards = new List<NumberCard>();
    private int currentIndex = 0;
    private bool isActive = true;

    void Start()
    {
        NumberPool pool = GetComponent<NumberPool>();

        foreach (var card in pool.NumberArray)
        {
            cards.Add(card);
            card.OnCardSelected += OnCardSelected;
        }

        if (cards.Count > 0)
        {
            EventSystem.current.SetSelectedGameObject(cards[currentIndex].gameObject);
        }
    }

    void Update()
    {
        if (!isActive || cards.Count == 0) return;

        // Handle navigation input
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex = (currentIndex + 1) % cards.Count;
            EventSystem.current.SetSelectedGameObject(cards[currentIndex].gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex = (currentIndex + cards.Count - 1) % cards.Count;
            EventSystem.current.SetSelectedGameObject(cards[currentIndex].gameObject);
        }
    }

    private void OnCardSelected(NumberCard card)
    {
        cards.Remove(card);

        if (cards.Count > 0)
        {
            currentIndex = Mathf.Min(currentIndex, cards.Count - 1);
            EventSystem.current.SetSelectedGameObject(cards[currentIndex].gameObject);
        }
        else
        {
            isActive = false;
        }
    }

    public void SetActive(bool active)
    {
        isActive = active;
    }
}
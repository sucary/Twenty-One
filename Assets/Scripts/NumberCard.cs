using UnityEngine;
using UnityEngine.UI;

public class NumberCard : MonoBehaviour
{
    public int cardValue { get; private set; }
    public bool isDrawn { get; private set; }
    public Button button;

    public void Initialize(int givenValue)
    {
        cardValue = givenValue;
        isDrawn = false;
        button = GetComponent<Button>();
    }
    
    public void OnCardDrawn()
    {
        isDrawn = true;
        button.interactable = false;
        Debug.Log($"Number {cardValue} drawn!");

        // TODO: visual or audio feedback
    }
}

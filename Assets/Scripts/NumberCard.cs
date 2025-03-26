using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberCard : MonoBehaviour
{
    public int CardValue { get; set; }
    public bool IsDrawn { get; set; }

    [SerializeField] public Button button;
    [SerializeField] private TextMeshProUGUI valueText;

    public System.Action<NumberCard> OnCardSelected;

    public void Initialize(int givenValue)
    {
        CardValue = givenValue;
        IsDrawn = false;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnCardDrawn);

        valueText.text = givenValue.ToString();
    }

    public void OnCardDrawn()
    {
        if (IsDrawn) return;

        IsDrawn = true;
        button.interactable = false;
        Debug.Log($"Number {CardValue} drawn!");

        OnCardSelected?.Invoke(this);

        // TODO: visual or audio feedback
    }
}

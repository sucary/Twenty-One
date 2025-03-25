using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberCard : MonoBehaviour
{
    public int CardValue { get; private set; }
    public bool IsDrawn { get; private set; }
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI valueText;

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
        IsDrawn = true;
        button.interactable = false;
        Debug.Log($"Number {CardValue} drawn!");

        // TODO: visual or audio feedback
    }
}

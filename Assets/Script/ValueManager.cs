using JetBrains.Annotations;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ValueManager : MonoBehaviour
{
    private float dollValue = 0f;
    private float totalYen = 0f;
    private float exchangeRate = 100f;

    public TextMeshProUGUI yenText;
    public TextMeshProUGUI dollText;
    public TextMeshProUGUI exchangeText;

    public Button convertButton;

    private void Update()
    {
        convertButton.interactable = dollValue > 0f;
    }

    public void AddClick()
    {
        dollValue += 1f;
        dollText.text = $"{dollValue} $";
        //Debug.Log($"ŠŽ‹à()F{dollValue} ");
    }

    public void ConvartYen()
    {
        float yen = dollValue * exchangeRate;
        totalYen += yen;
        dollValue = 0f;
        Debug.Log("“ú–{‰~‚ÉŠ·‹à‚µ‚Ü‚µ‚½B");
        //Debug.Log($"ŠŽ‹à(‰~)F{totalYen} ‰~");
        yenText.text = $"{totalYen} ‰~";
        dollText.text = $"{dollValue} $";
    }

    public void UpdateExchangeRate(float newRate)
    {
        exchangeRate = Mathf.Round((1f / newRate) * 100f) / 100f;
        exchangeText.text = $"1$ = {exchangeRate} ‰~";
        //Debug.Log("RateF" +  exchangeRate);
    }

    public bool CanSpend(float amount)
    {
        return totalYen >= amount;
    }

    public void Spend(float amount)
    {
        if (CanSpend(amount))
        {
            totalYen -= amount;
            yenText.text = $"{totalYen} ‰~";
        }
    }
}

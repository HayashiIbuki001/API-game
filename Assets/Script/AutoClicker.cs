using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoClicker : MonoBehaviour
{
    [SerializeField] ValueManager valueManager;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] private Button buyButton;

    private int level = 0;
    private float basePrice = 10f;

    private float timer = 0f;

    private void Update()
    {
        if (level > 0)
        {
            timer += Time.deltaTime;
            float currentInterval = Mathf.Max(1f - 0.1f * (level - 1), 0.01f);

            if (timer >= currentInterval)
            {
                timer = 0f;
                valueManager.AddClick();
            }
        }

        // ボタンの有効・無効切り替え
        if (buyButton != null)
        {
            buyButton.interactable = valueManager.CanSpend(GetPrice());
        }
    }

    public float GetPrice()
    {
        return basePrice * (level + 1) * (level + 1);
    }

    // 実際の購入処理（戻り値あり）
    public bool BuyAutoClicker()
    {
        float price = GetPrice();
        if (valueManager.CanSpend(price))
        {
            valueManager.Spend(price);
            level++;
            UpdatePrice(); // 価格表示も更新
            return true;
        }

        return false;
    }

    // ボタンのOnClickに登録するためのpublic voidメソッド
    public void OnBuyButtonClicked()
    {
        bool bought = BuyAutoClicker();
        if (!bought)
        {
            Debug.Log("お金が足りません");
        }
    }

    // 価格表示更新
    public void UpdatePrice()
    {
        float price = GetPrice();
        priceText.text = $"price: {price:F2} 円";
    }

    private void Start()
    {
        UpdatePrice(); // 最初に価格表示を更新しておく
    }
}

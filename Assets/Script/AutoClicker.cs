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

        // �{�^���̗L���E�����؂�ւ�
        if (buyButton != null)
        {
            buyButton.interactable = valueManager.CanSpend(GetPrice());
        }
    }

    public float GetPrice()
    {
        return basePrice * (level + 1) * (level + 1);
    }

    // ���ۂ̍w�������i�߂�l����j
    public bool BuyAutoClicker()
    {
        float price = GetPrice();
        if (valueManager.CanSpend(price))
        {
            valueManager.Spend(price);
            level++;
            UpdatePrice(); // ���i�\�����X�V
            return true;
        }

        return false;
    }

    // �{�^����OnClick�ɓo�^���邽�߂�public void���\�b�h
    public void OnBuyButtonClicked()
    {
        bool bought = BuyAutoClicker();
        if (!bought)
        {
            Debug.Log("����������܂���");
        }
    }

    // ���i�\���X�V
    public void UpdatePrice()
    {
        float price = GetPrice();
        priceText.text = $"price: {price:F2} �~";
    }

    private void Start()
    {
        UpdatePrice(); // �ŏ��ɉ��i�\�����X�V���Ă���
    }
}

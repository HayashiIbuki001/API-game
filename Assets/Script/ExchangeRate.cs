using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Timeline;

public class ExchangeRate : MonoBehaviour
{
    [SerializeField] ValueManager valueManager;

    private void Start()
    {
        StartCoroutine(GetExchangeRate());
        StartCoroutine(UpdateRateLoop());
    }

    IEnumerator GetExchangeRate()
    {
        string url = "https://open.er-api.com/v6/latest/JPY"; // API��URL
        UnityWebRequest www = UnityWebRequest.Get(url); // GET���N�G�X�g
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string json = www.downloadHandler.text; 
            //Debug.Log("�擾����JSON�F" + json);

            var rate = JsonUtility.FromJson<ExchangeRateResult>(json);
            float usdRate = rate.rates.USD;

            //Debug.Log("�擾�������[�g�F" + usdRate);
            valueManager.UpdateExchangeRate(usdRate);
        }
        else
        {
            Debug.LogError("API�擾���s");
        }
    }

    [System.Serializable]
    public class ExchangeRateResult
    {
        public Rates rates;
    }

    [System.Serializable]
    public class Rates
    {
        public float USD;
    }

    IEnumerator UpdateRateLoop()
    {
        while (true)
        {
            yield return StartCoroutine(GetExchangeRate());
            yield return new WaitForSeconds(30f); // 30�b���ɍX�V
        }
    }
}

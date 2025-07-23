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
        string url = "https://open.er-api.com/v6/latest/JPY"; // APIのURL
        UnityWebRequest www = UnityWebRequest.Get(url); // GETリクエスト
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string json = www.downloadHandler.text; 
            //Debug.Log("取得したJSON：" + json);

            var rate = JsonUtility.FromJson<ExchangeRateResult>(json);
            float usdRate = rate.rates.USD;

            //Debug.Log("取得したレート：" + usdRate);
            valueManager.UpdateExchangeRate(usdRate);
        }
        else
        {
            Debug.LogError("API取得失敗");
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
            yield return new WaitForSeconds(30f); // 30秒毎に更新
        }
    }
}

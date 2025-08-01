using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField,Tooltip("制限時間")] public float timeLimit = 300f;
    private float timer = 0f;
    /// <summary> 経過時間 </summary>
    private float remainingTime = 0f;

    public TextMeshProUGUI timerText;

    private void Start()
    {
        remainingTime = timeLimit;
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (remainingTime > 0)
        {
            timer += Time.deltaTime;
            remainingTime = timeLimit - timer;

            int minutes = (int)(remainingTime / 60);
            int seconds = (int)(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            remainingTime = 0f;
            GameEnd();
        }
        
    }

    private void GameEnd()
    {
        // ゲーム終了処理
    }
}

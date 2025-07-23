using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField,Tooltip("§ŒÀŠÔ")] public float timeLimit = 300f;
    private float timer = 0f;
    /// <summary> Œo‰ßŠÔ </summary>
    private float remainingTime = 0f;

    public TextMeshProUGUI timerText;

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
            timerText.text = string.Format("{0:00}{1:00}", minutes, seconds);
        }
        else
        {
            remainingTime = 0f;
            GameEnd();
        }
        
    }

    private void GameEnd()
    {
        // ƒQ[ƒ€I—¹ˆ—
    }
}

using System;
using UnityEngine;

public class DailySkill : MonoBehaviour
{
    [SerializeField] ValueManager valueManager;

    private void Start()
    {
        UpdateDayMultiplier();
    }

    /// <summary>
    /// —j“ú‚É‚æ‚é”{—¦‚ðvalueManager‚É‘ã“ü
    /// </summary>
    void UpdateDayMultiplier()
    {
        float rate = GetRateMultiplier();
        valueManager.dayMultiplier = rate;

        Debug.Log($"¡“ú‚Ì—j“ú‚Í{DateTime.Now.DayOfWeek}‚Å‚·BŠ·‹àŽž‚Ì”{—¦‚Í{rate}”{‚Å‚·B");
    }

    float GetRateMultiplier()
    {
        var day = DateTime.Now.DayOfWeek; // ¡“ú‚Ì—j“ú

        // ”{—¦
        return day switch
        {
            DayOfWeek.Saturday => 2f,
            DayOfWeek.Sunday => 3f,
            _ => 1f
        };
    }
}

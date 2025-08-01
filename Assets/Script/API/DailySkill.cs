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
    /// jϊΙζι{¦πvalueManagerΙγό
    /// </summary>
    void UpdateDayMultiplier()
    {
        float rate = GetRateMultiplier();
        valueManager.dayMultiplier = rate;

        Debug.Log($"‘ϊΜjϊΝ{DateTime.Now.DayOfWeek}Ε·B·ΰΜ{¦Ν{rate}{Ε·B");
    }

    float GetRateMultiplier()
    {
        var day = DateTime.Now.DayOfWeek; // ‘ϊΜjϊ

        // {¦
        return day switch
        {
            DayOfWeek.Saturday => 2f,
            DayOfWeek.Sunday => 3f,
            _ => 1f
        };
    }
}

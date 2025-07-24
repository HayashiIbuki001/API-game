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
    /// �j���ɂ��{����valueManager�ɑ��
    /// </summary>
    void UpdateDayMultiplier()
    {
        float rate = GetRateMultiplier();
        valueManager.dayMultiplier = rate;

        Debug.Log($"�����̗j����{DateTime.Now.DayOfWeek}�ł��B�������̔{����{rate}�{�ł��B");
    }

    float GetRateMultiplier()
    {
        var day = DateTime.Now.DayOfWeek; // �����̗j��

        // �{��
        return day switch
        {
            DayOfWeek.Saturday => 2f,
            DayOfWeek.Sunday => 3f,
            _ => 1f
        };
    }
}

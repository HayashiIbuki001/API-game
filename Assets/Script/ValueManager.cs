using JetBrains.Annotations;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class ValueManager : MonoBehaviour
{
    private int value;
    private int addValue;

    public void AddClick()
    {
        addValue = 1;

        value += addValue;
        Debug.Log(value);
    }
}

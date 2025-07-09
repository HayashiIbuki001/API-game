using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class ClickSystem : MonoBehaviour
{
    [SerializeField] ValueManager valueManager;

    public void OnClick()
    {
        valueManager.AddClick();
    }
}

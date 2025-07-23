using TMPro;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class ClickSystem : MonoBehaviour
{
    [SerializeField] ValueManager valueManager;
    [SerializeField] TextMeshProUGUI clickText;

    public void OnClick()
    {
        valueManager.AddClick();

        if (clickText != null )
        {
            clickText.gameObject.SetActive( false );
        }
    }
}

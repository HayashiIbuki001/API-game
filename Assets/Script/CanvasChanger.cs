using UnityEngine;

public class CanvasChanger : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject skillCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShowSkill();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ShowMain();
        }
    }

    public void ShowSkill()
    {
        mainCanvas.SetActive(false);
        skillCanvas.SetActive(true);
    }

    public void ShowMain()
    {
        mainCanvas.SetActive(true);
        skillCanvas.SetActive(false);
    }
}

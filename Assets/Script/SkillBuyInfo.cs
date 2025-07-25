using UnityEngine;

public class SkillBuyInfo : MonoBehaviour
{
    public GameObject skillInfoObj;
    public GameObject skillMainObj;

    public void pushInfo()
    {
        skillInfoObj.SetActive(true);
        skillMainObj.SetActive(false);
    }

    public void closeInfo()
    {
        skillInfoObj.SetActive(false);
        skillMainObj.SetActive(true);
    }
}

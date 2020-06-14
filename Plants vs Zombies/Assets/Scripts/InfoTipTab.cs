using UnityEngine;

public class InfoTipTab : MonoBehaviour
{
    private void OnMouseDown()
    {
        var obj = FindObjectsOfType<InfoTipTab>();
        foreach(InfoTipTab tab in obj)
        {
            tab.gameObject.SetActive(false);
        }

        gameObject.SetActive(true);
    }
}

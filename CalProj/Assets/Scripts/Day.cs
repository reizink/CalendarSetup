using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day : MonoBehaviour
{
    private int dayNum;
    private Color dayColor;
    private GameObject prefab;

    public void Initialize(int num, Color dcolor, GameObject dPrefab)
    {
        this.dayNum = num;
        this.dayColor = dcolor;
        this.prefab = dPrefab;
        UpdateColor(dayColor);
        UpdateDay(dayNum);
    }

    public void UpdateDay(int dNum)
    {
        this.dayNum = dNum;

        if(dayColor == Color.cyan || dayColor == Color.green)
        {
            prefab.GetComponentInChildren<TMP_Text>().text = (dayNum + 1).ToString();
        }
        else
        {
            prefab.GetComponentInChildren<TMP_Text>().text = "";
        }
    }

    public void UpdateColor(Color newColor)
    {
        prefab.GetComponent<Image>().color = newColor;
        dayColor = newColor;
    }
}

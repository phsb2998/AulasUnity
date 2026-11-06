using UnityEngine;
using UnityEngine.UI;

public class InventoryExemaple : MonoBehaviour
{
    public Image[] slots = new Image[0];

    public void AddItem(ItemData data)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].sprite == null)
            {
                slots[i].sprite = data.sprite;
                break;
            }
        }
    }
}

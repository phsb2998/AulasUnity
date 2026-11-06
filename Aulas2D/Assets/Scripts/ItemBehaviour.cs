using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public ItemData data;
    private SpriteRenderer renderer_;

    private void Start()
    {
        renderer_ = GetComponent<SpriteRenderer>();
        data.sprite = renderer_.sprite;
    }

    private void OnMouseDown()
    {
        InventoryExemaple inventory = FindAnyObjectByType<InventoryExemaple>();

        if (inventory != null)
        {
            inventory.AddItem(data);
        }
    }
}

using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] renderers_ = null;
    [SerializeField] private Color[] colors_ = null;
    [SerializeField] private Vector3 scale_ = Vector3.one;

    private void Start()
    {
        scale_ = transform.localScale;

        renderers_ = GetComponentsInChildren<SpriteRenderer>();
        colors_ = new Color[renderers_.Length];

        for (int i = 0; i < renderers_.Length; i++)
        {
            colors_[i] = renderers_[i].color;
        }
    }


    private void OnMouseEnter()
    {
        transform.localScale = scale_ * 1.15f;
    }


    private void OnMouseExit()
    {
        transform.localScale = scale_;
    }


    private void OnMouseDown()
    {
        for (int i = 0; i < renderers_.Length; i++)
        {
            renderers_[i].color = Color.yellow;
        }
    }

    private void OnMouseUp()
    {
        for (int i = 0; i < renderers_.Length; i++)
        {
            renderers_[i].color = colors_[i];
        }
    }

}

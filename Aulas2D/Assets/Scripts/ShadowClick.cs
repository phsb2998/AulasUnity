using UnityEngine;

public class ShadowClick : MonoBehaviour
{
    private SpriteRenderer renderer_;
    private SpriteRenderer shadow_;

    private void Start()
    {
        renderer_ = GetComponent<SpriteRenderer>();
        shadow_ = new GameObject(name + " Shadow").AddComponent<SpriteRenderer>();

        shadow_.transform.SetParent(transform);
        shadow_.transform.localPosition = Vector3.zero;
        shadow_.transform.localScale = Vector3.one * 1.2f;
        
        shadow_.sortingOrder = renderer_.sortingOrder - 1;
        shadow_.color = new Color(0f, 0f, 0f, 0.5f);
        
        shadow_.gameObject.SetActive(false);
    }

    private void Update()
    {
        shadow_.sprite = renderer_.sprite;
    }

    private void OnMouseEnter()
    {
        shadow_.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        shadow_.gameObject.SetActive(false);
    }
}

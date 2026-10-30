using UnityEngine;

public class ShadowCaster : MonoBehaviour
{
    public Vector2 offset = new Vector2(0.1f, -0.1f);
    [Range(0f, 1f)] public float opacity = 0.15f;

    private SpriteRenderer renderer_;
    private SpriteRenderer shadow_;

    private void Start()
    {
        renderer_ = GetComponent<SpriteRenderer>();
        shadow_ = new GameObject(renderer_.name + " Shadow").AddComponent<SpriteRenderer>();

        shadow_.transform.SetParent(renderer_.transform);
        shadow_.sortingOrder = renderer_.sortingOrder - 1;

        shadow_.transform.localScale = Vector3.one;
    }

    private void Update()
    {
        shadow_.transform.localPosition = offset;
        shadow_.color = new Color(0f, 0f, 0f, opacity);
        shadow_.sprite = renderer_.sprite;
    }
}

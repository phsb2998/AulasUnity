using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class TopDownMovement : MonoBehaviour
{
    public int totalPoints = 0;

    public Image hpBar;
    [Space]
    public float speed = 5f;
    public float maxHP = 10f;
    [SerializeField] private float hp_;

    private bool isAlive_ = true;
    private Rigidbody2D rb_;
    private Vector2 input_;

    private void Start()
    {
        hp_ = maxHP;
        UpdateHPBar();

        rb_ = GetComponent<Rigidbody2D>();
        rb_.gravityScale = 0f;
        rb_.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Update()
    {
        input_ = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        if (!isAlive_) return;
        rb_.linearVelocity = input_ * speed;
    }

    public void TakeDamage(float amount)
    {
        hp_ -= Mathf.Abs(amount);

        if (hp_ <= 0f)
        {
            hp_ = 0f;
            isAlive_ = false;
        }

        UpdateHPBar();
    }

    public void AddPoint(int points)
    {
        totalPoints += points;
        Debug.Log(totalPoints);
    }


    private void UpdateHPBar()
    {
        if (maxHP <= 0f) return;
        if (hpBar) hpBar.fillAmount = hp_ / maxHP;
    }
}

using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float changeColorTime = 1f;
    public float damage = 1f;
    public Color initialColor = Color.white;
    public Color endColor = Color.white;

    private float timer_ = 0f;
    private float timerMultiplier_ = 1f;
    private TopDownMovement player_;
    private SpriteRenderer renderer_;


    private void Start()
    {
        renderer_ = GetComponent<SpriteRenderer>();
        timer_ = Random.Range(0f, changeColorTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out TopDownMovement player))
        {
            player_ = player;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out TopDownMovement player))
        {
            player_ = null;
        }
    }

    private void Update()
    {
        timer_ += Time.deltaTime * timerMultiplier_;
        if (timer_ < 0 || timer_ > changeColorTime) Tick();

        renderer_.color = Color.Lerp(initialColor, endColor, timer_ / changeColorTime);
    }

    private void Tick()
    {
        if (player_) player_.TakeDamage(damage);

        if (timer_ < 0f) timer_ = 0f;
        if (timer_ > changeColorTime) timer_ = changeColorTime;

        timerMultiplier_ *= -1f;
    }
}

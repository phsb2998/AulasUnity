using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public int points = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool detected = false;

        if (other.TryGetComponent(out PlatformMovement platform))
        {
            platform.AddPoints(points);
            detected = true;
        }
        else if (other.TryGetComponent(out TopDownMovement topDown))
        {
            topDown.AddPoint(points);
            detected = true;
        }

        if (detected) Destroy(gameObject);
    }
}

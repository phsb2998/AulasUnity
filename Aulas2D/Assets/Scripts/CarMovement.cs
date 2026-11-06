using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 180f;
    public float driftSpeed = 360f;

    private Rigidbody2D rb_;

    private void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        float velocity = v * speed;
        float steering = Input.GetKey(KeyCode.Space) ? driftSpeed : turnSpeed;

        if (v != 0f)
        {
            transform.Rotate(Vector3.forward, -steering * h * Time.deltaTime);
        }

        rb_.linearVelocity = transform.up * velocity;
    }
}

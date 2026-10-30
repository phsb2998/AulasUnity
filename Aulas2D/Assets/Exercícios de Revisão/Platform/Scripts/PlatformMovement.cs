using UnityEngine;
using TMPro;

enum StateMachine
{
    Idle,
    Moving,
    Attacking,
    Dead
}


public class PlatformMovement : MonoBehaviour
{
    public TMP_Text pointsTMP;

    [Space]

    public float speed = 5f;
    public float jumpHeight = 3f;

    [Space]

    public float detectorRadius = 0.9f;
    public float detectorOffset = 0.05f;

    private CapsuleCollider2D col_;
    private Rigidbody2D rb_;
    private float input_;

    private int totalPoints_ = 0;
    private string originalText_;

    private float Radius => col_.size.x * 0.5f;
    private Vector3 Point => new Vector3(transform.position.x, transform.position.y - col_.size.y * 0.5f + Radius * (detectorRadius - detectorOffset), transform.position.z);

    private void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        col_ = GetComponent<CapsuleCollider2D>();

        if (pointsTMP) originalText_ = pointsTMP.text;
        AddPoints(0);
    }

    private void Update()
    {
        GetInputs();
    }

    private void FixedUpdate()
    {
        rb_.linearVelocityX = speed * input_;
    }

    private void OnDrawGizmos()
    {
        if (!col_) return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(Point, Radius * detectorRadius);
    }


    private bool IsGrounded()
    {
        foreach (Collider2D col in Physics2D.OverlapCircleAll(Point, Radius * detectorRadius))
        {
            if (col != col_) return true;
        }

        return false;
    }


    public void AddPoints(int points)
    {
        totalPoints_ += points;
        if (pointsTMP) pointsTMP.text = string.Format(originalText_, totalPoints_, points);
    }

    private void GetInputs()
    {
        input_ = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            float g = Mathf.Abs(Physics2D.gravity.y);
            rb_.linearVelocityY = Mathf.Sqrt(2f * g * jumpHeight);
        }
    }
}

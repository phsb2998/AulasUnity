using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public bool autoGo;

    public float speed = 5f;
    public float jumpForce = 200f;

    public bool isTopDown = false;
    public Rigidbody2D rb_;

    private SpriteRenderer sr_;

    private void Start()
    {
        sr_ = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (autoGo)
        {
            if (Vector3.Distance(Vector3.zero, transform.position) > 1f)
            {
                Vector2 dir = (Vector3.zero - transform.position).normalized;
                rb_.linearVelocity = dir * speed;
            }
            else
            {
                rb_.linearVelocity = Vector2.zero;
            }
            return;
        }

        float moveX = Input.GetAxis("Horizontal");

        if (isTopDown)
        {
            float moveY = Input.GetAxis("Vertical");

            Vector2 moveVector = new Vector2(moveX, moveY);
            moveVector.Normalize();

            rb_.linearVelocity = moveVector * speed;
        }
        else
        {
            rb_.linearVelocityX = moveX * speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb_.AddForce(Vector2.up * jumpForce);
            }
        }
    }



    private void OnMouseEnter()
    {
        sr_.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        sr_.color = Color.white;
    }

    private void OnMouseDown()
    {
        sr_.color = Color.darkBlue;
    }

    private void OnMouseUp()
    {
        sr_.color = Color.darkGreen;
    }

}

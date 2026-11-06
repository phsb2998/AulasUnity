using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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

    private List<GameObject> targets_ = new List<GameObject>();
    private float detectionDist = 2f;

    private void Start()
    {
        hp_ = maxHP;
        UpdateHPBar();

        rb_ = GetComponent<Rigidbody2D>();
        rb_.gravityScale = 0f;
        rb_.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        float minDistanceDetected = detectionDist;
        int foundIndex = -1;

        for (int i = 0; i < targets_.Count; i++)
        {
            float dist = Vector3.Distance(targets_[i].transform.position, transform.position);
            if (dist < minDistanceDetected)
            {
                minDistanceDetected = dist;
                foundIndex = i;
            }
        }

        if (foundIndex >= 0)
        {
            Transform finalTarget = targets_[foundIndex].transform;
        }
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

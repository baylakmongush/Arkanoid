using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Bonus : MonoBehaviour
{
    public Vector3 position;
    public float speed = 1;
    public DataScript DataScript;
    public GameObject Ball;
    CircleCollider2D coll;
    BoxCollider2D bonus_Collider;
    Ball classBall;
    public GameObject Paddle;

    public abstract void Skill();
    private void Start()
    {
        bonus_Collider = GetComponent<BoxCollider2D>();
        if (Ball != null)
            coll = Ball.GetComponent<CircleCollider2D>();
        classBall = Ball.GetComponent<Ball>();
    }
    private void Update()
    {
        position.y -= Time.deltaTime * speed;
        CheckCollision();
        // transform.position = position;
    }

    private void CheckCollision()
    {
        if (bonus_Collider.bounds.Intersects(coll.bounds))
        {
            Skill();
            Destroy(gameObject);
        }
    }
}

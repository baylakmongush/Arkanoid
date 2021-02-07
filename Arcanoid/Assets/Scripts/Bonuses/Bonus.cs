using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class of bonuses
/// </summary>
abstract public class Bonus : MonoBehaviour
{
    public Vector3 position;
    public float speed = 1;
    public DataScript DataScript;
    protected GameObject Ball;
    protected GameObject Paddle;
    public GameObject GameOver;
    CircleCollider2D coll;
    BoxCollider2D bonus_Collider;
    Ball classBall;

    /// <summary>
    /// current abstract method descriptions bonus's skills
    /// </summary>
    public abstract void Skill();

    private void Awake()
    {
        Ball = GameObject.Find("Ball");
        Paddle = GameObject.Find("Paddle");
    }

    private void Start()
    {
        position = transform.position;
        bonus_Collider = GetComponent<BoxCollider2D>();
        if (Ball != null)
            coll = Ball.GetComponent<CircleCollider2D>();
        classBall = Ball.GetComponent<Ball>();
    }
    private void Update()
    {
        if (Ball != null)
        {
            CheckCollision();
        }
            position.y -= Time.deltaTime * speed;
        transform.position = position;
        /*
         * When bonus is in Game over zone
         */
        if (transform.position.y < GameOver.transform.position.y)
            Destroy(gameObject);
    }

    /// <summary>
    /// Check collisions with ball
    /// </summary>
    private void CheckCollision()
    {
        if (bonus_Collider.bounds.Intersects(coll.bounds))
        {
            Skill();
            Destroy(gameObject);
        }
    }
}

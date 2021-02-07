using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public DataScript DataScript;
    Vector2 position;
    public bool touch = false;
    public GameObject WallR, WallL, Ceil;
    Collider2D ball_Collider;
    BoxCollider2D WallR_Collider, WallL_Collider, Ceil_Collider, paddle_Collider;
    public GameObject Paddle;
    public GameObject[] Block;
    public float change = -1.0f;
    bool start = true;
    public float speed;
    int[] sign = new int[] { 2, -1 };
    int randValue;
    float x_position;
    Paddle paddleClass;
    Block[] blockClass;
    Ball curr;

    void Start()
    {
        curr = GetComponent<Ball>();
        paddleClass = Paddle.GetComponent<Paddle>();
       for (int i = 0; i < Block.Length; ++i)
            blockClass[i] = Block[i].GetComponent<Block>();
        speed = DataScript.ball_speed;
        randValue = Random.Range(0, sign.Length);
        position = transform.position;
        ball_Collider = GetComponent<Collider2D>();
        if (WallR != null)
            WallR_Collider = WallR.GetComponent<BoxCollider2D>();
        if (WallL != null)
            WallL_Collider = WallL.GetComponent<BoxCollider2D>();
        if (Paddle != null)
            paddle_Collider = Paddle.GetComponent<BoxCollider2D>();
        if (Ceil != null)
            Ceil_Collider = Ceil.GetComponent<BoxCollider2D>();
    }

    float ChangeDirection(float _sign)
    {
        return (Mathf.Sin(Mathf.Clamp01(Time.deltaTime) * Mathf.PI * (-1) * _sign));
    }

    void Update()
    {
        speed = DataScript.ball_speed;
        if (start)
        {
            position.x += ChangeDirection(sign[randValue]);
        }
        WallsCollision();
        paddleClass.CheckCollision(gameObject, curr, ball_Collider);
        for (int i = 0; i < blockClass.Length; ++i)
            blockClass[i].CheckCollision(gameObject, curr, ball_Collider);
        transform.Rotate(Vector3.forward * 5f * speed, Space.World);
        if (!touch)
        {
            position.y += Time.deltaTime * speed;
        }
        else
        {
            position.y -= Time.deltaTime * speed;
        }
        position.x += ChangeDirection(change);
        transform.position = position;
        x_position = transform.position.x;
        DataScript.ball_speed = speed;
    }

    private void WallsCollision()
    {
        if (ball_Collider.bounds.Intersects(WallL_Collider.bounds))
        {
            start = false;
            change = -1;
            if (x_position != transform.position.x)
                speed += 0.05f;
        }
        if (ball_Collider.bounds.Intersects(WallR_Collider.bounds))
        {
            start = false;
            change = 1;
            if (x_position != transform.position.x)
                speed += 0.05f;
        }
        if (ball_Collider.bounds.Intersects(Ceil_Collider.bounds))
        {
            touch = true;
            speed += 0.05f;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public DataScript DataScript;
    float horiz;
    Vector3 new_position;
    public GameObject WallR;
    public GameObject WallL;
    BoxCollider2D paddle_Collider;
    float speed = 8.0f;
    public GameObject Ball;
    CircleCollider2D coll;
    Ball classBall;

    void Start()
    {
        new_position = transform.position;
        paddle_Collider = GetComponent<BoxCollider2D>();
        if (Ball != null)
            coll = Ball.GetComponent<CircleCollider2D>();
        classBall = Ball.GetComponent<Ball>();
    }

    void Update()
    {
        new_position = transform.position;
        horiz = Input.GetAxis("Horizontal");
        if (horiz != 0)
        {
            new_position.x += horiz * Time.deltaTime * speed;
        }
        transform.position = new_position.x > (WallL.transform.position.x + 1)
                                            && new_position.x < (WallR.transform.position.x - 1) ? new_position :
                                                                                                        transform.position;
    }

    public void CheckCollision()
    {
        if (paddle_Collider.bounds.Intersects(coll.bounds))
        {
            if (IsLeftSide())
            {
                classBall.change = 1;
                classBall.speed += 0.05f;
            }
            if (IsRightSide())
            {
                classBall.change = -1;
                classBall.speed += 0.05f;
            }
            if (IsTopSide())
            {
                classBall.touch = false;
                classBall.speed += 0.05f;
            }
            if (IsBottomSide())
            {
                classBall.touch = true;
                classBall.speed += 0.05f;
            }
        }
    }

    private bool IsLeftSide()
    {
        return (Ball.transform.position.y <= (transform.position.y + paddle_Collider.size.y / 2) &&
                        Ball.transform.position.y >= (transform.position.y - paddle_Collider.size.y / 2) &&
                                    Ball.transform.position.x <= transform.position.x);
    }

    private bool IsRightSide()
    {
        return (Ball.transform.position.y <= (transform.position.y + paddle_Collider.size.y / 2) &&
                        Ball.transform.position.y >= (transform.position.y - paddle_Collider.size.y / 2) &&
                                    Ball.transform.position.x >= transform.position.x);
    }

    private bool IsTopSide()
    {
        return (Ball.transform.position.x >= (transform.position.x - paddle_Collider.size.x / 2) &&
                        Ball.transform.position.x <= (transform.position.x + paddle_Collider.size.x / 2) &&
                                    Ball.transform.position.y >= transform.position.y);
    }

    private bool IsBottomSide()
    {
        return (Ball.transform.position.x >= (transform.position.x - paddle_Collider.size.x / 2) &&
                        Ball.transform.position.x <= (transform.position.x + paddle_Collider.size.x / 2) &&
                                    Ball.transform.position.y <= transform.position.y);
    }
}

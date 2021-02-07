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

    void Start()
    {
        new_position = transform.position;
        paddle_Collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        new_position = transform.position;
        horiz = Input.GetAxis("Horizontal");
        if (horiz != 0)
        {
            new_position.x += horiz * Time.deltaTime * speed;
        }
        transform.position = (new_position.x - paddle_Collider.size.x / 2) >= (WallL.transform.position.x - 1.5)
                                            && (new_position.x + paddle_Collider.size.x / 2) <= (WallR.transform.position.x + 1.5) ? new_position :
                                                                                                        transform.position;
    }

    public void CheckCollision(GameObject Ball,  Ball classBall, Collider2D coll)
    {
        if (paddle_Collider.bounds.Intersects(coll.bounds))
        {
            if (IsLeftSide(Ball))
            {
                classBall.change = 1;
                classBall.speed += 0.05f;
            }
            if (IsRightSide(Ball))
            {
                classBall.change = -1;
                classBall.speed += 0.05f;
            }
            if (IsTopSide(Ball))
            {
                classBall.touch = false;
                classBall.speed += 0.05f;
            }
            if (IsBottomSide(Ball))
            {
                classBall.touch = true;
                classBall.speed += 0.05f;
            }
        }
    }

    private bool IsLeftSide(GameObject Ball)
    {
        return (Ball.transform.position.y <= (transform.position.y + paddle_Collider.size.y / 2) &&
                        Ball.transform.position.y >= (transform.position.y - paddle_Collider.size.y / 2) &&
                                    Ball.transform.position.x <= transform.position.x);
    }

    private bool IsRightSide(GameObject Ball)
    {
        return (Ball.transform.position.y <= (transform.position.y + paddle_Collider.size.y / 2) &&
                        Ball.transform.position.y >= (transform.position.y - paddle_Collider.size.y / 2) &&
                                    Ball.transform.position.x >= transform.position.x);
    }

    private bool IsTopSide(GameObject Ball)
    {
        return (Ball.transform.position.x >= (transform.position.x - paddle_Collider.size.x / 2) &&
                        Ball.transform.position.x <= (transform.position.x + paddle_Collider.size.x / 2) &&
                                    Ball.transform.position.y >= transform.position.y);
    }

    private bool IsBottomSide(GameObject Ball)
    {
        return (Ball.transform.position.x >= (transform.position.x - paddle_Collider.size.x / 2) &&
                        Ball.transform.position.x <= (transform.position.x + paddle_Collider.size.x / 2) &&
                                    Ball.transform.position.y <= transform.position.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject Ball;
    CircleCollider2D coll;
    BoxCollider2D block_Collider;
    public GameObject Score;
    Ball classBall;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        block_Collider = GetComponent<BoxCollider2D>();
        if (Ball != null)
            coll = Ball.GetComponent<CircleCollider2D>();
        classBall = Ball.GetComponent<Ball>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 3f, 1f);
    }

    void Update()
    {
        if (block_Collider.bounds.Intersects(coll.bounds))
        {
            if (Ball.transform.position.y <= (transform.position.y + block_Collider.size.y / 2) && Ball.transform.position.y >= (transform.position.y - block_Collider.size.y / 2) && Ball.transform.position.x <= transform.position.x)
            {
                classBall.change = 1;
                classBall.speed += 0.1f;
            }
            if (Ball.transform.position.y <= (transform.position.y + block_Collider.size.y / 2) && Ball.transform.position.y >= (transform.position.y - block_Collider.size.y / 2) && Ball.transform.position.x >= transform.position.x)
            {
                classBall.change = -1;
                classBall.speed += 0.1f;
            }
            if (Ball.transform.position.x >= (transform.position.x - block_Collider.size.x / 2) && Ball.transform.position.x <= (transform.position.x + block_Collider.size.x / 2) && Ball.transform.position.y >= transform.position.y)
            {
                classBall.touch = false;
                classBall.speed += 0.1f;
            }
            if (Ball.transform.position.x >= (transform.position.x - block_Collider.size.x / 2) && Ball.transform.position.x <= (transform.position.x + block_Collider.size.x / 2) && Ball.transform.position.y <= transform.position.y)
            {
                classBall.touch = true;
                classBall.speed += 0.1f;
            }
            Score.GetComponent<SCore>().detected = true;
            Destroy(gameObject);
        }
    }
}

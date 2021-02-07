using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    public DataScript DataScript;
    public GameObject Ball;
    CircleCollider2D coll;
    BoxCollider2D block_Collider;
    public GameObject Score;
    Ball classBall;
    SpriteRenderer spriteRenderer;
    int lives;
    public NextLevel NextLevel;

    void Start()
    {
        if (DataScript.level != 1)
            lives = Random.Range(1, 4);
        else
            lives = 1;
        block_Collider = GetComponent<BoxCollider2D>();
        if (Ball != null)
            coll = Ball.GetComponent<CircleCollider2D>();
        classBall = Ball.GetComponent<Ball>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 3f, 1f);
    }

    void Update()
    {
        if (Ball != null)
            CheckCollision();
    }

    private void CheckCollision()
    {
        if (block_Collider.bounds.Intersects(coll.bounds))
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
            Score.GetComponent<SCore>().detected = true;
            DestroyBlock();
        }
    }

    void DestroyBlock()
    {
        if (lives == 1)
        {
            DataScript.CountBlocks--;
            if (DataScript.CountBlocks == 0 && DataScript.level < 3)
            {
                DataScript.level++;
                Destroy(coll.gameObject);
                NextLevel.StartLevel(0);
            }
            else
            {

            }
            Destroy(gameObject);
        }
        else
            lives--;
    }

    private bool IsLeftSide()
    {
        return (Ball.transform.position.y <= (transform.position.y + block_Collider.size.y / 2) &&
                        Ball.transform.position.y >= (transform.position.y - block_Collider.size.y / 2) &&
                                    Ball.transform.position.x <= transform.position.x);
    }

    private bool IsRightSide()
    {
        return (Ball.transform.position.y <= (transform.position.y + block_Collider.size.y / 2) &&
                        Ball.transform.position.y >= (transform.position.y - block_Collider.size.y / 2) &&
                                    Ball.transform.position.x >= transform.position.x);
    }

    private bool IsTopSide()
    {
        return (Ball.transform.position.x >= (transform.position.x - block_Collider.size.x / 2) &&
                        Ball.transform.position.x <= (transform.position.x + block_Collider.size.x / 2) &&
                                    Ball.transform.position.y >= transform.position.y);
    }

    private bool IsBottomSide()
    {
        return (Ball.transform.position.x >= (transform.position.x - block_Collider.size.x / 2) &&
                        Ball.transform.position.x <= (transform.position.x + block_Collider.size.x / 2) &&
                                    Ball.transform.position.y <= transform.position.y);
    }
}

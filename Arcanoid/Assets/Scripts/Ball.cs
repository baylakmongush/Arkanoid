using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public DataScript DataScript;
    public bool touch = false;
    public GameObject WallR, WallL, Ceil;
    public GameObject Paddle;
    public GameObject GameOver;
    public GameObject GameOverMenu;
    public List<GameObject> Block;
    public float change = -1.0f;
    public float speed;
    bool start = true;
    int[] sign = new int[] { 2, -1 };
    int randValue;
    float x_position;
    BoxCollider2D WallR_Collider, WallL_Collider, Ceil_Collider, paddle_Collider;
    Collider2D ball_Collider;
    Paddle paddleClass;
    List<Block> blockClass;
    Ball curr;
    Vector2 position;

    void Start()
    {
        blockClass = new List<Block>();
        curr = GetComponent<Ball>();
        paddleClass = Paddle.GetComponent<Paddle>();
        foreach (GameObject blocks in Block)
        {
            Block some = blocks.GetComponent<Block>();
            blockClass.Add(some);
            Debug.Log(blocks);
        }
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


    void Update()
    {
        speed = DataScript.ball_speed;
        if (start)
        {
            position.x += ChangeDirection(sign[randValue]);
        }
         WallsCollision();
        /*
         *  Check collisions with paddle
         */
        paddleClass.CheckCollision(gameObject, curr, ball_Collider);

        /*
         * For everyone blocks check collisions
         */
        for (int i = 0; i < 8; i++)
        {
            if (blockClass[i].IsActive())
            {
                blockClass[i].CheckCollision(gameObject, curr, ball_Collider);
            }
        }

        transform.Rotate(Vector3.forward * 5f * speed, Space.World); // Rotate ball

        /*
         * Change direction by y coords
         */
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

        /*
         *Check Game over Zone, if ball fell
         */
        if (transform.position.y < GameOver.transform.position.y)
        {
            GameOverMenu.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }
        DataScript.ball_speed = speed;
    }

    /// <summary>
    /// Change direction vector by reflection angle
    /// </summary>
    /// <param name="_sign"></param>
    /// <returns></returns>
    float ChangeDirection(float _sign)
    {
        return (Mathf.Sin(Mathf.Clamp01(Time.deltaTime) * Mathf.PI * (-1) * _sign));
    }

    /// <summary>
    /// Check wall collisions and change direction of moving
    /// </summary>
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


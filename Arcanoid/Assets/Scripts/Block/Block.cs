using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    public DataScript DataScript;
    public GameObject Ball;
    public GameObject Score;
    public NextLevel NextLevel;
    public GameObject[] Bonuses;
    public GameObject WinMenu;
    public Text score;
    SpriteRenderer spriteRenderer;
    CircleCollider2D coll;
    BoxCollider2D block_Collider;
    Ball classBall;
    int lives;

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

    /// <summary>
    /// Check collision with ball with block's side and change direction of moving
    /// </summary>
    /// <param name="Ball"></param>
    /// <param name="classBall"></param>
    /// <param name="coll"></param>
    /// <returns></returns>
    public bool CheckCollision(GameObject Ball, Ball classBall, Collider2D coll)
    {
        if (block_Collider.bounds.Intersects(coll.bounds))
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
            Score.GetComponent<SCore>().detected = true;
            if (DataScript.level == 3)
            {
                if (Random.value < 0.7)
                    Instantiate(Bonuses[Random.Range(0, 4)], gameObject.transform.position, Quaternion.identity);
            }
            if (DestroyBlock())
                return (true);
        }
        return (false);
    }

    /// <summary>
    /// check live of block
    /// </summary>
    /// <returns></returns>
    bool DestroyBlock()
    {
        if (lives == 1)
        {
            DataScript.CountBlocks--;
            if (DataScript.CountBlocks == 0 && DataScript.level < 3)
            {
                DataScript.level++;
                Destroy(coll.gameObject);
                PlayerPrefs.SetInt("curr_score", int.Parse(score.text) + 1);
                NextLevel.StartLevel(0);
            }
            else if (DataScript.CountBlocks == 0 && DataScript.level == 3)
            {
                Time.timeScale = 0;
                WinMenu.SetActive(true);
            }
            gameObject.SetActive(false);
            return (true);
        }
        else
            lives--;
        return (false);
    }

    /// <summary>
    /// Check current side
    /// </summary>
    /// <param name="Ball"></param>
    /// <returns></returns>
    private bool IsLeftSide(GameObject Ball)
    {
        return (Ball.transform.position.y <= (transform.position.y + block_Collider.size.y / 2) &&
                        Ball.transform.position.y >= (transform.position.y - block_Collider.size.y / 2) &&
                                    Ball.transform.position.x <= transform.position.x);
    }

    private bool IsRightSide(GameObject Ball)
    {
        return (Ball.transform.position.y <= (transform.position.y + block_Collider.size.y / 2) &&
                        Ball.transform.position.y >= (transform.position.y - block_Collider.size.y / 2) &&
                                    Ball.transform.position.x >= transform.position.x);
    }

    private bool IsTopSide(GameObject Ball)
    {
        return (Ball.transform.position.x >= (transform.position.x - block_Collider.size.x / 2) &&
                        Ball.transform.position.x <= (transform.position.x + block_Collider.size.x / 2) &&
                                    Ball.transform.position.y >= transform.position.y);
    }

    private bool IsBottomSide(GameObject Ball)
    {
        return (Ball.transform.position.x >= (transform.position.x - block_Collider.size.x / 2) &&
                        Ball.transform.position.x <= (transform.position.x + block_Collider.size.x / 2) &&
                                    Ball.transform.position.y <= transform.position.y);
    }

    /// <summary>
    /// Return active status of current game object
    /// </summary>
    /// <returns></returns>
    public bool IsActive()
    {
        return (gameObject.activeSelf);
    }
}

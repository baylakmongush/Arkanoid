using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public GameObject Ball;
    CircleCollider2D coll;
    BoxCollider2D block_Collider;
    public Text score;
    int sc;
    public GameObject Score;
    Ball classBall;

    void Start()
    {
        block_Collider = GetComponent<BoxCollider2D>();
        if (Ball != null)
            coll = Ball.GetComponent<CircleCollider2D>();

        sc = PlayerPrefs.GetInt("score");
        score.text = sc.ToString();
        classBall = Ball.GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (block_Collider.bounds.Intersects(coll.bounds))
        {
            if (Ball.transform.position.y <= (transform.position.y + block_Collider.size.y / 2) && Ball.transform.position.y >= (transform.position.y - block_Collider.size.y / 2) && Ball.transform.position.x <= transform.position.x)
            {
                //Debug.Log();
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

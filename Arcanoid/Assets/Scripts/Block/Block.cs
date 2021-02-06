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

    void Start()
    {
        block_Collider = GetComponent<BoxCollider2D>();
        if (Ball != null)
            coll = Ball.GetComponent<CircleCollider2D>();
        sc = PlayerPrefs.GetInt("score");
        score.text = sc.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (block_Collider.bounds.Intersects(coll.bounds))
        {
            if (Ball.transform.position.y < (transform.position.y + block_Collider.size.y / 2) && Ball.transform.position.y > (transform.position.y - block_Collider.size.y / 2) && Ball.transform.position.x < transform.position.x)
            {
                Ball.GetComponent<Ball>().change = 1;
            }
            if (Ball.transform.position.y < (transform.position.y + block_Collider.size.y / 2) && Ball.transform.position.y > (transform.position.y - block_Collider.size.y / 2) && Ball.transform.position.x > transform.position.x)
            {
                Ball.GetComponent<Ball>().change = -1;
            }
            if (Ball.transform.position.x < (transform.position.x - block_Collider.size.x / 2) && Ball.transform.position.x > (transform.position.x + block_Collider.size.x / 2) && Ball.transform.position.y > transform.position.y)
            {
                Ball.GetComponent<Ball>().touch = false;
            }
            if (Ball.transform.position.x < (transform.position.x - block_Collider.size.x / 2) && Ball.transform.position.x > (transform.position.x + block_Collider.size.x / 2) && Ball.transform.position.y < transform.position.y)
            {
                Ball.GetComponent<Ball>().touch = true;
            }
            Score.GetComponent<SCore>().detected = true;
            Destroy(gameObject);
            // if (block_Collider.bounds.size.x)
            // Ball.GetComponent<Ball>().Velocity += Vector3.down;
            /*            Vector3 newVec = Ball.transform.position - transform.position;
                        if (Ball.transform.position.y < (transform.position.y + block_Collider.size.y / 2) && Ball.transform.position.y > (transform.position.y - block_Collider.size.y / 2))
                        {
                            Debug.Log(newVec.magnitude);
                            if (newVec.magnitude == (coll.radius + block_Collider.size.x / 2))
                            {
                                Ball.GetComponent<Ball>().Velocity += Vector3.left;

                            }*/
        }
        Debug.Log("kk" + block_Collider.size.x);
    }
}

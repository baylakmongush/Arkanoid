using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 position;
    public bool touch = false;
    bool isPaddle = false;
    public GameObject m_MyObject, m_NewObject, newobj, aaaaa;
    public Collider2D ball_Collider;
    BoxCollider2D m_Collider2, m_Collider3, m_Collider4, paddle_Collider;
    List<BoxCollider2D> block_Collider;
    public GameObject Paddle;
    GameObject[] Block;
    public float change = -1.0f;
    public Vector3 velocity;
    bool start = true;

    public Vector3 Velocity
    {
        get => velocity;
        set => velocity = value;
    }

    void Start()
    {
        Block = GameObject.FindGameObjectsWithTag("Block");
        velocity = new Vector3(2, 1, 0);
        position = transform.position;
        if (m_MyObject != null)
            ball_Collider = m_MyObject.GetComponent<Collider2D>();
        if (m_NewObject != null)
            m_Collider2 = m_NewObject.GetComponent<BoxCollider2D>();
        if (m_NewObject != null)
            m_Collider3 = newobj.GetComponent<BoxCollider2D>();
        if (Paddle != null)
            paddle_Collider = Paddle.GetComponent<BoxCollider2D>();
        if (aaaaa != null)
            m_Collider4 = aaaaa.GetComponent<BoxCollider2D>();
/*        foreach (GameObject Bl in Block)
        {
            if (Bl != null)
               block_Collider.Add(Bl.GetComponent<BoxCollider2D>());
        }*/
    }

    float   ChangeDirection(float sign)
    {
        return (Mathf.Sin(Mathf.Clamp01(Time.deltaTime) * Mathf.PI * (-1) * sign));
    }

    void Update()
    {
        if (start)
        {
            position.x += ChangeDirection(-1);
        }
        if (ball_Collider.bounds.Intersects(m_Collider2.bounds))
        {
            // velocity = velocity + Vector3.right;
            change = -1;
        }
        else if (ball_Collider.bounds.Intersects(m_Collider3.bounds))
        {
            start = false;
            change = 1;
            // velocity = velocity + Vector3.left;
        }
        else if (ball_Collider.bounds.Intersects(paddle_Collider.bounds))
        {
            if (transform.position.y < (Paddle.transform.position.y + paddle_Collider.size.y / 2) && transform.position.y > (Paddle.transform.position.y - paddle_Collider.size.y / 2) && transform.position.x < Paddle.transform.position.x)
            {
                change = 1;
            }
            if (transform.position.y < (Paddle.transform.position.y + paddle_Collider.size.y / 2) && transform.position.y > (Paddle.transform.position.y - paddle_Collider.size.y / 2) && transform.position.x > Paddle.transform.position.x)
            {
                change = -1;
            }
            if (transform.position.x < (Paddle.transform.position.x - paddle_Collider.size.x / 2) && transform.position.x > (Paddle.transform.position.x + paddle_Collider.size.x / 2) && transform.position.y > Paddle.transform.position.y)
            {
               touch = false;
            }
            if (transform.position.x < (Paddle.transform.position.x - paddle_Collider.size.x / 2) && transform.position.x > (Paddle.transform.position.x + paddle_Collider.size.x / 2) && transform.position.y < Paddle.transform.position.y)
            {
               touch = true;
            }
            touch = false;
            // velocity = velocity + Vector3.up;
        }
        else if (ball_Collider.bounds.Intersects(m_Collider4.bounds))
        {
            touch = true;
          //  velocity = velocity + Vector3.down;
        }
       transform.Rotate(Vector3.forward * 5f, Space.World);
       // transform.Translate(velocity * Time.deltaTime, Space.World);
       if (!touch)
        {
            position.y += Time.deltaTime * 2.0f;
        }
       else
        {
            position.y -= Time.deltaTime * 2.0f;
        }
        position.x += ChangeDirection(change);
        transform.position = position;
    }
}

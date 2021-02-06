using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 position;
    public bool touch = false;
    public GameObject m_MyObject, m_NewObject, newobj, aaaaa;
    public Collider2D ball_Collider;
    BoxCollider2D m_Collider2, m_Collider3, m_Collider4, paddle_Collider;
    List<BoxCollider2D> block_Collider;
    public GameObject Paddle;
    public float change = -1.0f;
    public Vector3 velocity;
    bool start = true;
    public float speed = 5.0f;
    int[] sign = new int[] { 2, -1 };
    int randValue;
    float x_position;

    public Vector3 Velocity
    {
        get => velocity;
        set => velocity = value;
    }

    void Start()
    {
        randValue = Random.Range(0, sign.Length);
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
    }

    float   ChangeDirection(float _sign)
    {
        return (Mathf.Sin(Mathf.Clamp01(Time.deltaTime) * Mathf.PI * (-1) * _sign));
    }

    void Update()
    {
        if (start)
        {
            position.x += ChangeDirection(1);//sign[randValue]);
        }
        if (ball_Collider.bounds.Intersects(m_Collider2.bounds))
        {
            start = false;
            change = -1;
            if (x_position != transform.position.x)
                speed += 0.1f;
        }
        if (ball_Collider.bounds.Intersects(m_Collider3.bounds))
        {
            start = false;
            change = 1;
            if (x_position != transform.position.x)
                speed += 0.1f;
        }
        if (ball_Collider.bounds.Intersects(paddle_Collider.bounds))
        {
            touch = false;
            if (transform.position.y <= (Paddle.transform.position.y + paddle_Collider.size.y / 2) && transform.position.y >= (Paddle.transform.position.y - paddle_Collider.size.y / 2) && transform.position.x <= Paddle.transform.position.x)
            {
                change = 1;
                speed += 0.1f;
            }
            if (transform.position.y <= (Paddle.transform.position.y + paddle_Collider.size.y / 2) && transform.position.y >= (Paddle.transform.position.y - paddle_Collider.size.y / 2) && transform.position.x >= Paddle.transform.position.x)
            {
                change = -1;
                speed += 0.1f;
            }
            if (transform.position.x >= (Paddle.transform.position.x - paddle_Collider.size.x / 2) && transform.position.x <= (Paddle.transform.position.x + paddle_Collider.size.x / 2) && transform.position.y >= Paddle.transform.position.y)
            {
               touch = false;
                speed += 0.1f;
            }
            if (transform.position.x >= (Paddle.transform.position.x - paddle_Collider.size.x / 2) && transform.position.x <= (Paddle.transform.position.x + paddle_Collider.size.x / 2) && transform.position.y <= Paddle.transform.position.y)
            {
               touch = true;
                speed += 0.1f;
            }
        }
        if (ball_Collider.bounds.Intersects(m_Collider4.bounds))
        {
            touch = true;
            speed += 0.1f;
        }
       transform.Rotate(Vector3.forward * 5f * speed, Space.World);
        // transform.Translate(velocity * Time.deltaTime, Space.World);
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
    }
}

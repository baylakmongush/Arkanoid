using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float horiz;
    Vector3 new_position;
    public GameObject WallR;
    public GameObject WallL;
    Collider2D paddle_Collider;

    void Start()
    {
        new_position = transform.position;
        paddle_Collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        new_position = transform.position;
        horiz = Input.GetAxis("Horizontal");
        if (horiz != 0)
        {
            new_position.x += horiz * Time.deltaTime * 8.0f;
        }
        transform.position = new_position.x > (WallL.transform.position.x + 1)
                                            && new_position.x < (WallR.transform.position.x - 1) ? new_position :
                                                                                                        transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectCollPhysics : MonoBehaviour
{
    public GameObject[] sides;
    BoxCollider2D[] boxCollider2Ds = new BoxCollider2D[8];
    public GameObject BallBig;
    Collider2D ball_Collider;
    Ball ball;

    void Start()
    {
      // BallBig = GameObject.FindGameObjectWithTag("Ball");
       if (BallBig != null)
           ball = BallBig.GetComponent<Ball>();
       // ball_Collider = BallBig.GetComponent<Collider2D>();
        for (int i = 0; i < 8; i++)
        {
            boxCollider2Ds[i] = sides[i].GetComponent<BoxCollider2D>();
        }
    }

    void Update()
    {
        Bounds ballBounds = ball.ball_Collider.bounds;
      ballBounds.extents += Vector3.forward * Mathf.Infinity;
        Bounds wall0 = boxCollider2Ds[0].bounds;
       wall0.extents += Vector3.forward * Mathf.Infinity;
        Bounds wall1 = boxCollider2Ds[1].bounds;
       wall1.extents += Vector3.forward * Mathf.Infinity;
        Bounds wall2 = boxCollider2Ds[2].bounds;
       wall2.extents += Vector3.forward * Mathf.Infinity;
        Bounds wall3 = boxCollider2Ds[3].bounds;
       wall3.extents += Vector3.forward * Mathf.Infinity;
        Bounds wall4 = boxCollider2Ds[4].bounds;
      wall4.extents += Vector3.forward * Mathf.Infinity;
        Bounds wall5 = boxCollider2Ds[5].bounds;
        wall5.extents += Vector3.forward * Mathf.Infinity;
        Bounds wall6 = boxCollider2Ds[6].bounds;
       wall6.extents += Vector3.forward * Mathf.Infinity;
        Bounds wall7 = boxCollider2Ds[7].bounds;
       wall7.extents += Vector3.forward * Mathf.Infinity;

        if (ballBounds.Intersects(wall0))
        {
            Debug.Log("sdfsfdsf0");
            ball.velocity += new Vector3(-1, 1, 0);
        }
        if (ballBounds.Intersects(wall1))
        {
            Debug.Log("sdfsfdsf1");
            ball.velocity += Vector3.up;
        }
        if (ballBounds.Intersects(wall2))
        {
            Debug.Log("sdfsfdsf2");
            ball.velocity += new Vector3(1, 1, 0);
        }
        if (ballBounds.Intersects(wall3))
        {
            Debug.Log("sdfsfdsf3");
            ball.velocity += Vector3.left;
        }
        if (ballBounds.Intersects(wall4))
        {
            Debug.Log("sdfsfdsf4");
            ball.velocity += Vector3.right;
        }
        if (ballBounds.Intersects(wall5))
        {
            Debug.Log("sdfsfdsf5");
            ball.velocity += new Vector3(-1, -1, 0);
        }
        if (ballBounds.Intersects(wall6))
        {
            Debug.Log("sdfsfdsf6");
            ball.velocity += Vector3.down;
        }
        if (ballBounds.Intersects(wall7))
        {
            Debug.Log("sdfsfdsf7");
            ball.velocity += new Vector3(1, -1, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : Bonus
{
    Vector3 scale;
    public override void Skill()
    {
        scale = Paddle.transform.localScale;
        scale.x += 0.2f;
        Paddle.transform.localScale = scale;
    }
}


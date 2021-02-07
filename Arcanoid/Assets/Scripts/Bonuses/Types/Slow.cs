using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : Bonus
{
    public override void Skill()
    {
        DataScript.ball_speed -= 1;
    }
}

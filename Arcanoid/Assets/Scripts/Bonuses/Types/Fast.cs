using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast : Bonus
{
    public override void Skill()
    {
        DataScript.ball_speed += 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Currect class speeds duplicated ball
/// </summary>
public class Fast : Bonus
{
    public override void Skill()
    {
        DataScript.ball_speed += 1;
    }
}

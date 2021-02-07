using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Currect class creates duplicated ball
/// </summary>
public class Duplicate : Bonus
{
    public override void Skill()
    {
        Instantiate(Ball);
    }
}

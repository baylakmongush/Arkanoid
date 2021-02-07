using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicate : Bonus
{
    public override void Skill()
    {
        Instantiate(Ball);
    }
}

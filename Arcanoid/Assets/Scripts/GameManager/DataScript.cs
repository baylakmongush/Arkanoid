using UnityEngine;

[CreateAssetMenu(fileName = "DataScript", menuName = "ScriptableObjects/DataScript", order = 1)]
public class DataScript : ScriptableObject
{
    public float ball_speed;
    public int score = 0;
    public int level = 1;
    public int CountBlocks;
}

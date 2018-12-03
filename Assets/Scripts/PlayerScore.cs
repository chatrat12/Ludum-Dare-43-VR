using UnityEngine;

public static class PlayerScore
{
    public static float Score { get; set; }

    public static void Add(float points) => Score += points;
    public static void Reset() => Score = 0;
}

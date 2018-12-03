using UnityEngine;

public static class PlayerScore
{
    public static float Score { get; private set; }
    public static int Casualties { get; private set; }

    public static void Add(float points) => Score += points;
    public static void AddCasualties(int casualties) => Casualties += casualties;
    public static void Reset() { Score = 0; Casualties = 0; }
}

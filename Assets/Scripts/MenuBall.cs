using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBall : GrippableObject
{
    public delegate void MenuBallEvent(MenuBall sender);
    public event MenuBallEvent Activated;

    public override void OnGripped(HandGrip gripper, Vector3 velocity)
    {
        Activated?.Invoke(this);
    }

    public override void OnReleased(HandGrip gripper, Vector3 velocity)
    {
        // Don't do anything
    }
}

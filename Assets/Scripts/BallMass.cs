using UnityEngine;

public class BallMass : MonoBehaviour
{
    public bool Attached { get; private set; } = false;

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void OnAttach(GameBall ball)
    {
        Attached = true;
        this.gameObject.layer = LayerMask.NameToLayer("BallMass");
    }
}

using UnityEngine;

public class BallMass : MonoBehaviour
{
    public bool Attached { get; private set; } = false;
    public int Casualties => _casualties;
    public float Score => _score;
    public Rigidbody Rigidbody { get; private set; }

    [SerializeField] private float _score = 10;
    [SerializeField] private int _casualties = 1;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void OnAttach(GameBall ball)
    {
        Attached = true;
        this.gameObject.layer = LayerMask.NameToLayer("BallMass");
            PlayerScore.AddCasualties(Casualties);
    }
}

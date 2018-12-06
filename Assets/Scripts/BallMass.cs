using UnityEngine;

public class BallMass : MonoBehaviour
{
    public bool Attached { get; private set; } = false;
    public int Casualties => _casualties;
    public float Score => _score;
    public Rigidbody Rigidbody { get; private set; }

    [SerializeField] private float _score = 10;
    [SerializeField] private int _casualties = 1;

    private bool _casualtiesCounted = false;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void OnAttach(GameBall ball)
    {
        Attached = true;
        Rigidbody.isKinematic = false;
        if (!_casualtiesCounted)
        {
            PlayerScore.AddCasualties(Casualties);
            _casualtiesCounted = true;
        }
    }

    public void Detach()
    {
        Attached = false;
    }
}

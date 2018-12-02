using UnityEngine;

public class BallMassCollector : MonoBehaviour
{
    private GameBall _gameBall;

    private void Awake()
    {
        _gameBall = GetComponentInParent<GameBall>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var mass = other.GetComponent<BallMass>();
        if (mass != null && !mass.Attached)
        {
            _gameBall.AttachMass(mass);
        }
    }
}

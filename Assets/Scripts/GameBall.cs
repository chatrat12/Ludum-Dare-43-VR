using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameBall : GrippableObject
{

    public float AttachedMass => _masses.Sum(m => m.Rigidbody.mass);
    public float MassScore => _masses.Sum(m => m.Score);
    [SerializeField] private float _force = 100;
    [SerializeField] private float _killVelocity = 0.1f;
    [SerializeField] private float _killTime = 2.0f;

    private List<BallMass> _masses = new List<BallMass>();
    private float _timeStill;

    private void FixedUpdate()
    {
        foreach (var mass in _masses)
            mass.Rigidbody.AddForce((transform.position - mass.transform.position) * _force);
        if (!Rigidbody.isKinematic)
        {
            _timeStill = Rigidbody.velocity.magnitude < _killVelocity ? _timeStill + Time.fixedDeltaTime : 0;
            if(_timeStill >= _killTime)
                Destroy(this.gameObject);
        }

        // Kill if to low
        if (transform.position.y < -10)
            Destroy(this.gameObject);
    }


    public void OnDestroy()
    {
        foreach (var mass in _masses)
            mass.Detach();
    }

    public void AttachMass(BallMass mass)
    {
        _masses.Add(mass);
        mass.OnAttach(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        var mass = other.GetComponent<BallMass>();
        if (mass != null && !mass.Attached)
        {
            _masses.Add(mass);
            mass.OnAttach(this);
        }
    }


    private Bounds? GetBounds()
    {
        var colliders = GetComponentsInChildren<Collider>().Where(c => !c.isTrigger);
        if (colliders.Any())
        {
            var bounds = colliders.First().bounds;
            foreach(var c in colliders)
                bounds.Encapsulate(c.bounds);
            return bounds;
        }
        return null;
    }
}

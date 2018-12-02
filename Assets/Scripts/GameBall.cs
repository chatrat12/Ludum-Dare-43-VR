using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameBall : GrippableObject
{
    [SerializeField] private float _force = 100;

    private List<BallMass> _masses = new List<BallMass>();

    private void FixedUpdate()
    {
        foreach (var mass in _masses)
            mass.Rigidbody.AddForce((transform.position - mass.transform.position) * _force);
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

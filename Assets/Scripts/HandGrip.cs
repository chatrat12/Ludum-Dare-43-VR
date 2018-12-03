using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(GripInput), typeof(TriggerVolume))]
public class HandGrip : MonoBehaviour
{
    public bool IsLeftHand { get; private set; }

    private TriggerVolume _triggerVolume;
    private List<GrippableObject> _grippables = new List<GrippableObject>();
    private GrippableObject _grippedObject;
    private Vector3 _prevPosition;
    private Quaternion _prevRotation;
    private Vector3 _velocity;
    private Quaternion _angularVelocity;

    private void Awake()
    {
        _prevPosition = transform.position;
        _prevRotation = transform.rotation;
        _triggerVolume = GetComponent<TriggerVolume>();
        var input = GetComponent<GripInput>();
        input.Activated += (sender) => Grip();
        input.Deactivated += (sender) => ReleaseGrip();
        IsLeftHand = input.Hand == GripInput.HandType.Left;
    }

    private void LateUpdate()
    {
        _velocity = (transform.position - _prevPosition) / Time.deltaTime;
        _prevPosition = transform.position;
    }

    private void Grip()
    {
        // TODO: Find closest to hand
        var grippables = _triggerVolume.GetComponentsInVolume(ref _grippables);
        var first = grippables.Where(g => !g.Gripped).FirstOrDefault();
        if (first != null)
        {
            _grippedObject = first;
            _grippedObject.OnGripped(this, _velocity);
        }

    }

    private void ReleaseGrip()
    {
        if (_grippedObject != null)
        {
            _grippedObject.OnReleased(this, _velocity);
            _grippedObject = null;
        }
    }
}

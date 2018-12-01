using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(GripInput), typeof(TriggerVolume))]
public class HandGrip : MonoBehaviour
{
    private TriggerVolume _triggerVolume;
    private List<GrippableObject> _grippables = new List<GrippableObject>();
    private GrippableObject _grippedObject;
    private Vector3 _prevPosition;
    private Vector3 _velocity;
    private Vector3 _anchor;

    private void Awake()
    {
        _prevPosition = transform.position;
        _triggerVolume = GetComponent<TriggerVolume>();
        var input = GetComponent<GripInput>();
        input.Activated += (sender) => Grip();
        input.Deactivated += (sender) => ReleaseGrip();
    }

    private void FixedUpdate()
    {
        _velocity = (transform.position - _prevPosition);//* Time.fixedDeltaTime;
        _prevPosition = transform.position;
        if(_grippedObject != null)
        {
            _grippedObject.Rigidbody.MovePosition(transform.position + _anchor);
        }
        //Debug.Log(_velocity);
    }

    private void Grip()
    {
        // TODO: Find closes to hand
        var grippables = _triggerVolume.GetComponentsInVolume(ref _grippables);
        var first = grippables.FirstOrDefault();
        if (first != null)
        {
            _grippedObject = first;
            _grippedObject.Rigidbody.isKinematic = false;
            _anchor = _grippedObject.transform.position - transform.position;
            _grippedObject.OnGripped(this.transform, _velocity);
        }

    }

    private void ReleaseGrip()
    {
        if (_grippedObject != null)
        {
            _grippedObject.OnReleased(this.transform, _velocity);
            _grippedObject = null;
        }
    }
}

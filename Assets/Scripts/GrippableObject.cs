using UnityEngine;
using UnityEngine.SpatialTracking;

public class GrippableObject : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }

    [SerializeField] private float _throwVelocityModifier = 1f;
    [SerializeField] private Transform _snappingTransfrom;

    protected void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void OnGripped(Transform parent, Vector3 velocity)
    {
        transform.SetParent(parent);
        Rigidbody.isKinematic = true;
        if(_snappingTransfrom != null)
        {
            var offset = _snappingTransfrom.position - transform.position;
            transform.position = parent.position;
            transform.position += parent.rotation * offset;
            transform.rotation = parent.rotation * _snappingTransfrom.rotation;
        }
    }

    public virtual void OnReleased(Transform parent, Vector3 velocity)
    {
        transform.SetParent(null);
        Rigidbody.isKinematic = false;
        Rigidbody.velocity = velocity * _throwVelocityModifier;
        
    }
}

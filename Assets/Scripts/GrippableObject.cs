using UnityEngine;

public class GrippableObject : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }
    public bool Gripped { get; private set; } = false;

    [SerializeField] private float _throwVelocityModifier = 1f;
    [SerializeField] private Transform _snappingTransfrom;

    protected void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void OnGripped(HandGrip gripper, Vector3 velocity)
    {
        transform.SetParent(gripper.transform);
        Rigidbody.isKinematic = true;
        Gripped = true;
        if(_snappingTransfrom != null)
        {
            var offset = _snappingTransfrom.localPosition;
            transform.position = gripper.transform.position;
            transform.localPosition += offset; //gripper.transform.rotation * offset;
            transform.rotation = gripper.transform.rotation * _snappingTransfrom.rotation;

            // Fix left hand snapping
            if (gripper.IsLeftHand)
            {
                var localPos = transform.localPosition;
                localPos.x = -localPos.x;
                transform.localPosition = localPos;
            }
        }
    }

    public virtual void OnReleased(HandGrip gripper, Vector3 velocity)
    {
        Gripped = false;
        transform.SetParent(null);
        Rigidbody.isKinematic = false;
        Rigidbody.velocity = velocity * _throwVelocityModifier;
    }
}

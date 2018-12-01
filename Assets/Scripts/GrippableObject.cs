using UnityEngine;
using UnityEngine.SpatialTracking;

public class GrippableObject : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }

    protected void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Debug.Log(_rigidbody.velocity);
    }

    public virtual void OnGripped(Transform parent, Vector3 velocity)
    {
        transform.SetParent(parent);
        Rigidbody.isKinematic = true;
    }

    public virtual void OnReleased(Transform parent, Vector3 velocity)
    {
        transform.SetParent(null);
        Rigidbody.isKinematic = false;
        Rigidbody.velocity = velocity;
        
    }
}

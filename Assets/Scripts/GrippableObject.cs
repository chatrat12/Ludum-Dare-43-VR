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
        //transform.SetParent(parent);
        //_rigidbody.isKinematic = true;
    }

    public virtual void OnReleased(Transform parent, Vector3 velocity)
    {
        //transform.SetParent(null);
        //_rigidbody.isKinematic = false;
        //_rigidbody.velocity = velocity * 100;
        
    }
}

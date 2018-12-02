using System.Linq;
using UnityEngine;

public class DestructableModel : MonoBehaviour
{
    [SerializeField] private GameObject _fracturedModel;
    [SerializeField] private float _breakForce = 100;

    private void OnCollisionEnter(Collision collision)
    {
        var mass = collision.collider.GetComponentsInChildren<Rigidbody>().Sum(rb => rb.mass);

        if (collision.relativeVelocity.magnitude * mass > _breakForce)
        {
            // Disable previous collision so we can spawn in
            // the fractured model
            GetComponent<Collider>().enabled = false;
            var fracturedModel = Instantiate(_fracturedModel, transform.position, transform.rotation);
            Destroy(this.gameObject);

            // Apply impact force to debris
            var rigidbodies = fracturedModel.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
                rb.AddForce(collision.relativeVelocity * mass, ForceMode.Force);

        }
    }
}

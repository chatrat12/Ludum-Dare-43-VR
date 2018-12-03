using UnityEngine;

public class HandMesh : MonoBehaviour
{
    [SerializeField] private Mesh _gripMesh;

    private void Awake()
    {
        var filter = GetComponentInChildren<MeshFilter>();
        var ogMesh = filter.mesh;

        var input = GetComponentInParent<GripInput>();
        input.Activated += (sender) => filter.mesh = _gripMesh;
        input.Deactivated += (sender) => filter.mesh = ogMesh;
    }
}

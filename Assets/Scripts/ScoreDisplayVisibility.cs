using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayVisibility : MonoBehaviour
{
    [SerializeField] private float _lookAtThreshold = 0.5f;
    [SerializeField] private float _upThreshold = 0.5f;
    

    private Canvas _canvas;
    private CanvasScaler _scaler;
    private Animator _animator;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        _scaler = GetComponent<CanvasScaler>();
        _animator = GetComponent<Animator>();
        _canvas.enabled = _scaler.enabled = false;
        
    }

    private void Update()
    {
        var camTransfrom = Camera.main.transform;
        var cameraToDisplay = (transform.position - camTransfrom.position).normalized;
        // Make sure wrist is facing HMD
        var l = Vector3.Dot(transform.forward, cameraToDisplay) > _lookAtThreshold;
        // Make sure wrist is pointing up.
        var u = Vector3.Dot(-transform.up, Vector3.up) > _upThreshold;

        bool visible = l && u;
        if(visible && !_canvas.enabled)
            _canvas.enabled = _scaler.enabled = true;

        _animator.SetBool("Visible", visible);
    }

}

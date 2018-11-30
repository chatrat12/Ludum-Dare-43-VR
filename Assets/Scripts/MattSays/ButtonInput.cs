using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public delegate void ButtonEvent(ButtonInput sender);
    public event ButtonEvent Pressed;
    public event ButtonEvent Released;

    public bool Touched { get; private set; } = false;

    [SerializeField] private float _triggerTime = 0.05f; // 50ms
    private float _timeTouched = 0;


    private void Update()
    {
        if (Touched)
        {
            if (_timeTouched < _triggerTime &&
               _timeTouched + Time.deltaTime >= _triggerTime)
            {
                Pressed?.Invoke(this);
            }
            _timeTouched += Time.deltaTime;
        }
        else
        {
            if (_timeTouched >= _triggerTime)
            {
                _timeTouched = 0;
                Released?.Invoke(this);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _timeTouched = 0;
        Touched = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // This is kind of hacky. Won't handle
        // multiple objects interacting with the 
        // button at once. :D
        Touched = false;
    }

    public void RemoveHandlers()
    {
        if (Pressed != null)
        {
            foreach (var d in Pressed.GetInvocationList())
                Pressed -= (ButtonEvent)d;
        }
        if (Released != null)
        {
            foreach (var d in Released.GetInvocationList())
                Released -= (ButtonEvent)d;
        }
    }
}

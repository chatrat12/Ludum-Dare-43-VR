using UnityEngine;

public class GripInput : MonoBehaviour
{
    public delegate void GripInputEvent(GripInput sender);
    public event GripInputEvent Activated;
    public event GripInputEvent Deactivated;

    public bool Active { get; private set; }
    public HandType Hand => _hand;


    [SerializeField] private HandType _hand;

    private const float ACTIVATION_THRESHOLD   = 0.6f;
    private const float DEACTIVATION_THRESHOLD = 0.5f;

    private string _gripButton => _hand == HandType.Left ? "Left Grip" : "Right Grip";

	void Update ()
    {
        var axis = Input.GetAxis(_gripButton);

        if (!Active && axis >= ACTIVATION_THRESHOLD)
        {
            Active = true;
            Activated?.Invoke(this);
        }
        else if (Active && axis <= DEACTIVATION_THRESHOLD)
        {
            Active = false;
            Deactivated.Invoke(this);
        }
	}

    public enum HandType
    {
        Left,
        Right
    }
}

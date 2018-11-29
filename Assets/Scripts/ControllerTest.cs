using UnityEngine;


public class ControllerTest : MonoBehaviour
{
    [SerializeField] private Light _light;

	void Update ()
    {
        if (Input.GetButtonDown("Test"))
            _light.enabled = !_light.enabled;
		
	}
}

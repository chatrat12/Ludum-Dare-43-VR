using UnityEngine;
using UnityEngine.XR;

public class GameCamera : MonoBehaviour
{
    private void Awake()
    {
        // Testing to see if HMD is connected. Will try to make 
        // game at least run without one.

        // TODO: something :D
        Debug.Log(XRSettings.isDeviceActive);
    }

}

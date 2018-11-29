using UnityEngine;
using UnityEditor;

public static class VRUtil
{
    [MenuItem("VR/Enable")]
    private static void EnableVR()
    {
        PlayerSettings.virtualRealitySupported = true;
        Debug.Log("VR Enabled");
    }

    [MenuItem("VR/Disable")]
    private static void DisableVR()
    {
        PlayerSettings.virtualRealitySupported = false;
        Debug.Log("VR Disabled");
    }
}

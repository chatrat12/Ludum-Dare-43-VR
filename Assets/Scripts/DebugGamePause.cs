#if UNITY_EDITOR
using UnityEngine;

public class DebugGamePause : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButton("DebugPause"))
            UnityEditor.EditorApplication.isPaused = true;
    }
}
#endif
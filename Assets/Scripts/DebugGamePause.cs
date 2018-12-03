#if UNITY_EDITOR
using UnityEngine;

public class DebugGamePause : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButton("DebugPause"))
        {
            var balls = FindObjectsOfType<GameBall>();
            foreach (var ball in balls)
            {
                if (!ball.Rigidbody.isKinematic)
                {
                    foreach (var rb in ball.GetComponentsInChildren<Rigidbody>())
                        Destroy(rb);
                    foreach (var collider in ball.GetComponentsInChildren<Collider>())
                        Destroy(collider);

                    Destroy(ball);
                    ball.GetComponentInChildren<TrailRenderer>().time = float.MaxValue;
                }
            }
        }
    }
}
#endif
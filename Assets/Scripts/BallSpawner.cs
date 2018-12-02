using System.Linq;
using UnityEngine;

[RequireComponent(typeof(TriggerVolume))]
public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameBall _ballPrefab;

    private void Awake()
    {
        var triggerVolume = GetComponent<TriggerVolume>();
        GetComponent<TriggerVolume>().TriggerExited += (collider) =>
        {
            // If game ball left trigger volume and no game balls, spawn new ball
            if (collider.GetComponent<GameBall>() != null
                && !triggerVolume.CollidersInVolume.Any(c => c.GetComponent<GameBall>() != null))
            {
                SpawnBall();
            }
        };
        SpawnBall();
    }

    private void SpawnBall()
    {
        Instantiate(_ballPrefab, transform.position, Quaternion.identity);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, 0.25f * 0.5f);
    }
#endif
}

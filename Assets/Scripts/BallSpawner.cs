using UnityEngine;

[RequireComponent(typeof(TriggerVolume))]
public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameBall _ballPrefab;

    private void Awake()
    {
        GetComponent<TriggerVolume>().TriggerExited += (collider) =>
        {
            // If game ball left trigger volume, spawn new ball
            if (collider.GetComponent<GameBall>() != null)
                SpawnBall();
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

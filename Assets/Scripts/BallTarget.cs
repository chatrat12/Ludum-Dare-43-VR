using UnityEngine;

public class BallTarget : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var ball = collision.collider.GetComponent<GameBall>();
        if(ball != null)
        {
            PlayerScore.Add(ball.AttachedMass);
            Destroy(ball.gameObject);
        }
    }
}

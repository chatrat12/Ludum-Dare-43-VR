using UnityEngine;

public class BallTarget : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var ball = collision.collider.GetComponent<GameBall>();
        if(ball != null)
        {
            PlayerScore.Add(ball.MassScore);
            Destroy(ball.gameObject);
        }
    }
}

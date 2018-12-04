using System.Linq;
using UnityAsync;
using UnityEngine;

public class BallTarget : MonoBehaviour
{
    [SerializeField] private bool _destroyOnHit = false;

    private async void OnCollisionEnter(Collision collision)
    {
        var ball = collision.collider.GetComponent<GameBall>();
        if(ball != null)
        {
            PlayerScore.Add(ball.MassScore);
            Destroy(ball.gameObject);

            if(_destroyOnHit)
            {
                Destroy(this);
                await Await.NextFixedUpdate();
                if (!FindObjectsOfType<BallTarget>().Any())
                    ShowGameOver();
            }
        }
    }

    private void ShowGameOver()
    {
        var menu = FindObjectOfType<GameMenu>();
        if (menu != null)
            menu.ShowGameOver();
    }
}
